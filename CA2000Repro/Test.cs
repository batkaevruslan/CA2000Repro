namespace CA2000Repro
{
    public class Test
    {
        public static async Task ConvertWithLoopAsync()
        {
            foreach (int _ in Enumerable.Range(0, 1))
            {
                using Foo pdfDocument = new(); //CA2000 => object created by 'new()' should be disposed
                await PrepareForRenderingAsync();
            }
        }

        public static async Task ConvertAsync()
        {
            using Foo pdfDocument = new(); //OK
            await PrepareForRenderingAsync();
        }

        private static async Task PrepareForRenderingAsync()
        {
            await using Stream targetStream = File.Create("");
        }

        private sealed class Foo : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}