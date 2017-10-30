using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<Tyre> tyres;

    public Car(string model)
    {
        this.Model = model;
        this.tyres = new List<Tyre>();
    }

    internal string Model
    {
        get
        {
            return this.model;
        }

        set
        {
            this.model = value;
        }
    }

    internal Engine Engine
    {
        get
        {
            return this.engine;
        }

        set
        {
            this.engine = value;
        }
    }

    internal Cargo Cargo
    {
        get
        {
            return this.cargo;
        }

        set
        {
            this.cargo = value;
        }
    }

    internal void AddTyre(Tyre tyre)
    {
        this.tyres.Add(tyre);
    }

    internal IReadOnlyList<Tyre> Tyres
    {
        get
        {
            return this.tyres.AsReadOnly();
        }
    }
}
