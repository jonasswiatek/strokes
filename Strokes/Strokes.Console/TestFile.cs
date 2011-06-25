namespace CSharpAchiever.Console
{
    public class TestFile
    {
        public string SomeProperty { get; set; }

        public TestFile(string someProperty)
        {
            SomeProperty = someProperty;

           var kk = new
                         {
                             s = "kk"
                         };
        }
        /*
        public void DoSomething(params object[] blas)
        {
            IEnumerable<String> someEnum = null;

            var bla = someEnum.Where(a => a.StartsWith("1"));
            var hhh = from b in someEnum
                      where b.StartsWith("1")
                      select b;

            for (var i = 0; i <= 10; i++)
            {
                
            }

            foreach (var bladd in someEnum)
            {

            }

            do
            {

            } while (someEnum != null);

            while(someEnum != null)
            {
                
            }

            try
            {

            }
            finally
            {
                var c = "";
            }

            try
            {

            }
            catch
            {
                    
            }
            finally
            {
                var c = "";
            }
        }

        public static void bla(string[] args)
        {
            Console.WriteLine("Hello World");
        }*/
    }
}
