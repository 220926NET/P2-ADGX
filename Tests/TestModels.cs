using Models;
public class TestProfileModels
{

    [Fact]
    public void TEST_VISION_API_MODEL()
    {
        // Given
        List<string> Tags = new List<string>(){
                "moon",
                "airplane",
                "sky"
            };
        string description = "A plane flying in front of the moon.";
        // When 
        VisionApiResponse visionApi = new VisionApiResponse()
        {
            Tags = Tags,
            Description = description
        };
        // Then

        Assert.Equal(visionApi.Tags, Tags);
        Assert.Equal(visionApi.Description, description);
    }


}