using System.Text;
using CS14_DI_In_Advance;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseRouting();
app.UseEndpoints(ep =>
{
    ep.MapGet("/showOptions", async context =>
    {
        // Lay ra doi tuong IOptionsSnapshot
        // IOptionsSnapshot la 1 service de lay ra cac options
        var configuration = context.RequestServices.GetRequiredService<IConfiguration>();
        var testOptions = configuration.GetSection("TestOptions").Get<TestOptions>();
        // var testOption1 = testOptions["TestOption1"];
        // var k1 = testOptions.GetSection("TestOption2")["k1"];
        // var k2 = testOptions.GetSection("TestOption2")["k2"];
        
        var sb = new StringBuilder();
        // sb.Append("TestOption\n");
        // sb.Append($"TestOption1: {testOption1}\n");
        // sb.Append($"k1: {k1}\n");
        // sb.Append($"k2: {k2}\n");
        sb.Append("TestOption\n");
        sb.Append($"TestOption1: {testOptions.TestOption1}\n");
        sb.Append($"k1: {testOptions.TestOption2.k1}\n");
        sb.Append($"k2: {testOptions.TestOption2.k2}\n");
        await context.Response.WriteAsync(sb.ToString());
    });
});
app.Run();