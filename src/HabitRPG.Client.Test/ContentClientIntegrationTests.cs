using NUnit.Framework;

namespace HabitRPG.Client.Test
{
    public class ContentClientIntegrationTests : IntegrationBase
    {
        private readonly IContentClient _contentClient;

        public ContentClientIntegrationTests()
        {
            _contentClient = new ContentClient(HabitRpgConfiguration);
        }

        [Test]
        public void Should_get_content()
        {
            var getContentAsyncResponse = _contentClient.GetContentAsync();
            getContentAsyncResponse.Wait();

            Assert.IsNotNull(getContentAsyncResponse.Result);
            Assert.IsNotEmpty(getContentAsyncResponse.Result.Gear.Flat);
            Assert.IsNotEmpty(getContentAsyncResponse.Result.Pets);
        }

        [Test]
        public void Should_get_different_language_content()
        {
            var getContentAsyncResponse = _contentClient.GetContentAsync("de");
            getContentAsyncResponse.Wait();

            Assert.IsNotNull(getContentAsyncResponse.Result);
            Assert.IsNotEmpty(getContentAsyncResponse.Result.Gear.Flat);
            Assert.IsNotEmpty(getContentAsyncResponse.Result.Pets);
        }
    }
}
