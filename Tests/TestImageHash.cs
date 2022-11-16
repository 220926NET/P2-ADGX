
using BusinessLogicLayer;
public class TestImageHash
{


    [Fact]
    public void TestName()
    {
        var content = "Hello World from a Fake File";
        var fileName = "test.pdf";
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(content);
        writer.Flush();
        stream.Position = 0;

        //create FormFile with desired data
        IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
        string hash = ImageHash.GetImageHash(file, "this is a test", "emmora2");
        string hash2 = ImageHash.GetImageHash(file, "this is a second post", "emmora2");
        Assert.NotEmpty(hash);
        Assert.NotEmpty(hash2);
        Assert.NotEqual(hash, hash2);
    }



}