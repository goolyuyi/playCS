namespace playCS
{
    class POCOClass
    {
        public string Fields { get; set; }
    }

    class ReadonlyClass
    {
        public string InitStr { get; init; }

        public readonly string ReadOnlyStr;

        public ReadonlyClass(string cSharpNineReadOnlyStr)
        {
            ReadOnlyStr = cSharpNineReadOnlyStr;
        }
    }

    struct MyStruct
    {
        public string S { get; init; }
        public string S2 { readonly get; set; }
        public readonly string S3 { get; init; }
    }

    public class PlayPOCO
    {
    }
}