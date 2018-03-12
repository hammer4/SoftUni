using System.Collections.Generic;

/// <summary>
/// <para>
/// The IProductStock interface provides a set of methods which
/// should be implemented by your data structure. </para>
/// <para>All of the
/// below-written methods will be tested so, please,
/// do not modify them in any way. </para>
/// <para>>You can add methods to the concrete class though.</para>
/// </summary>
public interface IProductStock : IEnumerable<Product>
{
    //Properties
    int Count { get; }
    
    //Validations
    bool Contains(Product product);
    
    //Modifications
    void Add(Product product);
    void ChangeQuantity(string product, int quantity);

    //Retrievals
    Product Find(int index);
    Product FindByLabel(string label);
    IEnumerable<Product> FindFirstByAlphabeticalOrder(int count);

    //Querying
    IEnumerable<Product> FindAllInRange(double lo, double hi);
    IEnumerable<Product> FindAllByPrice(double price);
    IEnumerable<Product> FindFirstMostExpensiveProducts(int count);
    IEnumerable<Product> FindAllByQuantity(int quantity);

}