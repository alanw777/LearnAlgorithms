namespace AlgorithmsWithCs.SymbolTable
{
    public class STTest
    {
        public static void Test()
        {
            var bst = new STWithBST<string, int>();
            bst.Put("wang yi", 80);
            bst.Put("li si", 60);
            bst.Put("zhang san", 99);
            var score = bst.Get("zhang san");
            Utils.Log("zhang san score = " + score);
            score = bst.Get("li si");
            Utils.Log("li si score = " + score);
            score = bst.Get("wang yi");
            Utils.Log("wang yi score = " + score);
            Utils.Log("size : " + bst.Size());

//            bst.DelMin();
//            
//            Utils.Log("min :" + bst.Min());
//            Utils.Log("max : " + bst.Max());
//            
//            bst.DelMax();
//            
//            Utils.Log("min :" + bst.Min());
//            Utils.Log("max : " + bst.Max());
//            bst.Delete("wang yi");
//            Utils.Log("min :" + bst.Min());
//            Utils.Log("max : " + bst.Max());
            Utils.Log("floor x : "+bst.Floor("x"));
            Utils.Log("floor u : "+bst.Floor("u"));
            Utils.Log("floor zhang san : "+bst.Floor("zhang san"));
            
            Utils.Log("ceil x : "+bst.Ceil("x"));
            Utils.Log("ceil u : "+bst.Ceil("u"));
            Utils.Log("ceil zhang san : "+bst.Ceil("zhang san"));
        }
    }
}