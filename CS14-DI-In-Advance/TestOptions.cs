namespace CS14_DI_In_Advance;

public class TestOptions
{
    public string TestOption1 { get; set; }
    public SubTestOptions TestOption2 { get; set; }
}

public class SubTestOptions
{
    public string k1 { get; set; }
    public string k2 { get; set; }
}