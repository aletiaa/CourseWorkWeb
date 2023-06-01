public class ProductsRepository 
{
    private ShopContext _db;
    public ProductsRepository(ShopContext db)
    {
        _db = db;
    }

    public List<Product> GetAllProducts()
    { 
        return _db.Products.ToList();
    }

    public List<Product> GetRandomThreeProducts()
    { 
        return _db.Products
                    .OrderBy(p => Guid.NewGuid())
                    .Take(3)
                    .ToList();
    }

    public void Add(Product product)
    {
        _db.Products.Add(product);
        _db.SaveChanges();
    }

    public void Remove(int id)
    {
        Product removeProduct = FindProduct(id);
        _db.Products.Remove(removeProduct);
        _db.SaveChanges();
    }

    public Product FindProduct(int id)
    {
        Product foundProduct = _db.Products.FirstOrDefault(product => product.ID == id);
        return foundProduct;
    }
}