using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WebServer.Contracts;
using WebServer.Enums;
using WebServer.Exceptions;
using WebServer.Http.Contracts;
using WebServer.Http.Response;

namespace SimpleMvc.Framework.Routers
{
    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParameters;
        private IDictionary<string, string> postParameters;
        private string requestMethod;
        private object controllerInstance;
        private string controllerName;
        private string actionName;
        private object[] methodParameters;

        public IHttpResponse Handle(IHttpRequest request)
        {
            this.getParameters = new Dictionary<string, string>(request.UrlParameters);
            this.postParameters = new Dictionary<string, string>(request.FormData);
            this.requestMethod = request.Method.ToString().ToUpper();

            this.PrepareControllerAndActionNames(request);

            var methodInfo = this.GetActionForExecution();
            if (methodInfo == null)
            {
                return new NotFoundResponse();
            }

            this.PrepareMethodParameters(methodInfo);

            var actionResult = (IInvocable)methodInfo.Invoke(
                this.GetControllerInstance(),
                this.methodParameters);

            var content = actionResult.Invoke();

            return new ContentResponse(HttpStatusCode.Ok, content);
        }

        private void PrepareMethodParameters(MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters();

            this.methodParameters = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];

                // GET
                if (parameter.ParameterType.IsPrimitive ||
                    parameter.ParameterType == typeof(string))
                {
                    var parameterValue = this.getParameters[parameter.Name];

                    var value = Convert.ChangeType(
                        parameterValue,
                        parameter.ParameterType);

                    this.methodParameters[i] = value;
                }
                else // POST
                {
                    var modelType = parameter.ParameterType;
                    var modelInstance = Activator.CreateInstance(modelType);

                    var modelProperties = modelType.GetProperties();

                    foreach (var modelProperty in modelProperties)
                    {
                        var parameterValue = this.postParameters[modelProperty.Name];

                        var value = Convert.ChangeType(
                            parameterValue,
                            modelProperty.PropertyType);

                        modelProperty.SetValue(
                            modelInstance,
                            value);
                    }

                    this.methodParameters[i] = Convert.ChangeType(
                        modelInstance,
                        modelType);
                }
            }
        }

        private MethodInfo GetActionForExecution()
        {
            var methods = this.GetSuitableMethods();

            foreach (var method in methods)
            {
                var httpMethodAttributes = method
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>();

                // No attribute & GET method
                if (!httpMethodAttributes.Any() && this.requestMethod == "GET")
                {
                    return method;
                }

                // Attribute & valid method (GET/POST)
                foreach (var httpMethodAttribute in httpMethodAttributes)
                {
                    if (httpMethodAttribute.IsValid(this.requestMethod))
                    {
                        return method;
                    }
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            var controller = this.GetControllerInstance();

            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                  .GetType()
                  .GetMethods()
                  .Where(m => m.Name == this.actionName);
        }

        private object GetControllerInstance()
        {
            var controllerFullQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                this.controllerName);

            var controllerType = Type.GetType(controllerFullQualifiedName);

            if (controllerType == null)
            {
                return null;
            }

            this.controllerInstance = Activator.CreateInstance(controllerType);

            return this.controllerInstance;
        }

        private void PrepareControllerAndActionNames(IHttpRequest request)
        {
            // <host>/{controllerName}/{actionName}?{query_string}
            var pathTokens = request.Path
                            .Split(new[] { '/', '?' }, StringSplitOptions.RemoveEmptyEntries);

            // required controller & action
            if (pathTokens.Length < 2)
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            var controllerFirstLetter = char.ToUpper(pathTokens[0].First());
            var controllerRest = pathTokens[0].Substring(1);

            this.controllerName = $"{controllerFirstLetter}{controllerRest}{MvcContext.Get.ControllersSuffix}";

            var actionFirstLetter = char.ToUpper(pathTokens[1].First());
            var actionRest = pathTokens[1].Substring(1);

            this.actionName = $"{actionFirstLetter}{actionRest}";
        }
    }
}
