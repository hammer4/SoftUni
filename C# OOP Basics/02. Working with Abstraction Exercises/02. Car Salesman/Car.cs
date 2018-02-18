using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private string model;
    private Engine engine;
    private int? weight;
    private string color;

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
    }

    public Car(string model, Engine engine, int? weight)
        : this(model, engine)
    {
        this.weight = weight;
    }

    public Car(string model, Engine engine, string color)
        :this(model, engine)
    {
        this.color = color;
    }

    public Car(string model, Engine engine, int? weight, string color)
        :this(model, engine)
    {
        this.weight = weight;
        this.color = color;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"{model}:");
        builder.Append(engine);
        builder.AppendLine($"  Weight: {(weight == null ? "n/a" : weight.ToString())}");
        builder.Append($"  Color: {(color == null ? "n/a" : color)}");

        return builder.ToString();
    }
}
