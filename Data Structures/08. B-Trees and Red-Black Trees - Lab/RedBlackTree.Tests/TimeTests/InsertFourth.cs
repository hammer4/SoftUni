using NUnit.Framework;

[TestFixture]
class InsertFourth
{
    [Test]
    [Timeout(500)]
    public void Insert_MultipleElements_ShouldBeFast()
    {
        RedBlackTree<int> rbt = new RedBlackTree<int>();

        for (int i = 0; i < 100000; i++)
        {
            rbt.Insert(i);
        }
        
    }
}
