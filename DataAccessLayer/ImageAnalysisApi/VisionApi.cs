
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Models;
namespace DataAccessLayer;
public class VisionApi
{

    private readonly string _subscriptionKey = "";
    private readonly string _endpoint = "";


    ///<Summary> Returns a <c>VisionApiResponse</c> containing a list of tags and a description</Summary>
    ///<params>image url </params>
    public async Task<VisionApiResponse> GetTagsAndDescription(string imageUrl)
    {
        ComputerVisionClient client = Authenticate(_endpoint, _subscriptionKey);

        VisionApiResponse response = await AnalyzeImageUrl(client, imageUrl);

        return response;
    }

    public ComputerVisionClient Authenticate(string endpoint, string key)
    {

        ComputerVisionClient client =
          new ComputerVisionClient(new ApiKeyServiceClientCredentials(_subscriptionKey))
          { Endpoint = _endpoint };

        return client;
    }

    public async Task<VisionApiResponse> AnalyzeImageUrl(ComputerVisionClient client, string imageUrl)
    {

        VisionApiResponse response = new VisionApiResponse();
        List<string> tags = new List<string>();
        try
        {
            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Tags,
                VisualFeatureTypes.Description
            };

            ImageAnalysis results = await client.AnalyzeImageAsync(imageUrl, visualFeatures: features);
            tags.Add(results.Tags[0].Name);
            tags.Add(results.Tags[1].Name);
            tags.Add(results.Tags[2].Name);

            response.Tags = tags;
            response.Description = results.Description.Captions[0].Text;


        }
        catch (Exception e)
        {
            // TODO: Log an error 
            Console.WriteLine("an exception occured when generating image tags");
            Console.WriteLine(e);
        }

        return response;

    }

}