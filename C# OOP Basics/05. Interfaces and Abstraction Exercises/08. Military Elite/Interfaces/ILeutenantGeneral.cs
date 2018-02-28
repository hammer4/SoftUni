using System;
using System.Collections.Generic;
using System.Text;

public interface ILeutenantGeneral : IPrivate
{
    IReadOnlyCollection<IPrivate> Privates { get; }
}