using Moq;
using Movies.Services.Interfaces;
using Movies.Services.Models;

namespace Movies.Tests
{
    public class ActorServiceTests
    {
        private readonly Mock<IActorService> _actorService;

        public ActorServiceTests()
        {
            _actorService = new Mock<IActorService>();
        }

        private Actor GetMockupActor()
        {
            return new Actor()
            {
                ActorId = 1,
                Name = "Name Test",
            };
        }

        private IEnumerable<Actor> GetMockupActors()
        {
            var actors = new List<Actor>
            {
                new Actor()
                {
                    ActorId = 2,
                    Name = "Name Test 2"
                },
                 new Actor()
                {
                    ActorId = 3,
                    Name = "Name Test 3"
                }
            };

            return actors;
        }

        [Fact]
        public async Task GetActor_Should_Return_Actor_By_Id()
        {
            var actorId = 1;
            _actorService.Setup(x => x.GetActor(actorId)).ReturnsAsync(GetMockupActor());

            var actor = await _actorService.Object.GetActor(actorId);

            Assert.NotNull(actor);
            Assert.Equal(actorId, actor!.ActorId);
            Assert.Equal("Name Test", actor!.Name);
        }

        [Fact]
        public async Task GetActors_Should_Return_All_Actors()
        {
            _actorService.Setup(x => x.GetActors("a")).ReturnsAsync(GetMockupActors());

            var actors = await _actorService.Object.GetActors("a");

            Assert.NotNull(actors);
            Assert.True(actors.Count() > 0);
        }
    }
}