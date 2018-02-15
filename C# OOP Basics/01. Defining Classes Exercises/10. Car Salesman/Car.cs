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
        this.Model = model;
        this.Engine = engine;
    }

    public Car(string model, Engine engine, int? weight)
        : this(model, engine)
    {
        this.Weight = weight;
    }

    public Car(string model, Engine engine, string color)
        :this(model, engine)
    {
        this.Color = color;
    }

    public Car(string model, Engine engine, int? weight, string color)
        :this(model, engine)
    {
        this.Weight = weight;
        this.Color = color;
    }

    public string Color
    {
        get { return color; }
        private set { color = value; }
    }

    public int? Weight
    {
        get { return weight; }
        private set { weight = value; }
    }

    public Engine Engine
    {
        get { return engine; }
        private set { engine = value; }
    }

    public string Model
    {
        get { return model; }
        private set { model = value; }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"{Model}:");
        builder.Append(Engine);
        builder.AppendLine($"  Weight: {(Weight == null ? "n/a" : Weight.ToString())}");
        builder.Append($"  Color: {(Color == null ? "n/a" : Color)}");

        return builder.ToString();
    }
}
