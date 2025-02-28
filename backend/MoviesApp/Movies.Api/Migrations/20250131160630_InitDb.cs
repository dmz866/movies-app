﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "MovieRatings",
                columns: table => new
                {
                    MovieRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRatings", x => x.MovieRatingId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    ActorsActorId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.ActorsActorId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_ActorMovie_Actors_ActorsActorId",
                        column: x => x.ActorsActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => x.MovieActorId);
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieMovieRating",
                columns: table => new
                {
                    MovieRatingsMovieRatingId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMovieRating", x => new { x.MovieRatingsMovieRatingId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_MovieMovieRating_MovieRatings_MovieRatingsMovieRatingId",
                        column: x => x.MovieRatingsMovieRatingId,
                        principalTable: "MovieRatings",
                        principalColumn: "MovieRatingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieMovieRating_Movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Robert Anthony De Niro is an American actor and film producer. He is considered to be one of the greatest and most influential actors of his generation.[a] De Niro is the recipient of various accolades, including two Academy Awards and a Golden Globe Award as well as nominations for eight BAFTA Awards and four Emmy Awards. He was honored with the AFI Life Achievement Award in 2003, the Kennedy Center Honors in 2009, the Cecil B. DeMille Award in 2011, and the Screen Actors Guild Life Achievement Award in 2019. De Niro was presented with the Presidential Medal of Freedom by U.S. president Barack Obama in 2016.", "https://upload.wikimedia.org/wikipedia/commons/2/25/Robert_De_Niro_Cannes_2016_2.jpg", "Robert De Niro" },
                    { 2, "John Joseph Nicholson (born April 22, 1937) is an American retired actor and filmmaker.[1] Nicholson is widely regarded as one of the greatest actors of the 20th century.[2][3] Throughout his five-decade career he received numerous accolades, including three Academy Awards, three BAFTA Film Awards, six Golden Globe Awards, and a Grammy Award. He also received the American Film Institute's Life Achievement Award in 1994 and the Kennedy Center Honor in 2001. In many of his films, he played rebels against the social structure.", "https://upload.wikimedia.org/wikipedia/commons/e/ec/Jack_Nicholson_2001.jpg", "Jack Nicholson" },
                    { 4, "Marlon Brando Jr. (April 3, 1924 – July 1, 2004) was an American actor. Widely regarded as one of the greatest cinema actors of the 20th century,[1][2] Brando received numerous accolades throughout his career, which spanned six decades, including two Academy Awards, three British Academy Film Awards, a Cannes Film Festival Award, two Golden Globe Awards, and a Primetime Emmy Award. Brando is credited with being one of the first actors to bring the Stanislavski system of acting and method acting to mainstream audiences.", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Marlon_Brando_publicity_for_One-Eyed_Jacks.png/934px-Marlon_Brando_publicity_for_One-Eyed_Jacks.png", "Marlon Brando" },
                    { 5, "Denzel Hayes Washington Jr. (born December 28, 1954) is an American actor, producer, and director. Known for his dramatic roles on stage and screen, The New York Times named him the greatest actor of the 21st century in 2020.[2][3] He has received several accolades, including two Academy Awards, three Golden Globe Awards, and a Tony Award as well as nominations for two Emmy Awards and a Grammy Award. Washington has been honored with the Cecil B. DeMille Award in 2016, AFI Life Achievement Award in 2019, and the Presidential Medal of Freedom in 2025.", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/Denzel_Washington_at_the_2024_Toronto_International_Film_Festival_02_%28cropped%29.jpg/989px-Denzel_Washington_at_the_2024_Toronto_International_Film_Festival_02_%28cropped%29.jpg", "Denzel Washington" }
                });

            migrationBuilder.InsertData(
                table: "MovieRatings",
                columns: new[] { "MovieRatingId", "MovieId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 9m },
                    { 2, 1, 8m },
                    { 3, 1, 8.7m },
                    { 4, 2, 7m },
                    { 5, 2, 6.7m },
                    { 6, 2, 8.1m },
                    { 7, 3, 9.2m },
                    { 8, 3, 9.1m }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Making his uber cool and supremely confident directorial debut, Quentin Tarantino hit audiences with a terrific twist on the heist-gone-wrong thriller. For the most part a single location chamber piece, Reservoir Dogs delights in ricocheting the zing and fizz of its dialogue around its gloriously —and indeed gore-iously) — intense setting, with the majority of the movie's action centring around one long and incredibly bloody death scene. Packing killer lines, killer needledrops, and killer, er, killers too, not only is this a rollicking ride in its own right, but it also set the blueprint for everything we've come to expect from a Tarantino joint. Oh, and by the way: Nice Guy Eddie was shot by Mr. White. Who fired twice. Case closed.", "https://images.bauerhosting.com/legacy/media/5d2d/e61a/853e/7cc4/4bcc/fb99/reservoir-dogs.jpg?auto=format&w=1200&q=80", "Reservoir Dogs" },
                    { 2, "Bill Murray is at the height of his (eventually) lovable schmuck powers as narcissistic weatherman Phil Connors. Andie McDowell brings the brains and the heart as distant-but-ever-closer-coming producer Rita Hanson. And Harold Ramis, directing and co-writing with Danny Rubin, manages to spin gold from the well-worn thread of a man stuck in time. Whilst this time-loop dramedy might not have been the first film to drink from this particular trope's well, it is inarguably head and shoulders above the rest. Murray's customarily snarky delivery gets the easy laughs flowing early doors, but it's the way the movie finds deeper things to say about existence and morals as it goes on, all whilst never feeling overly preachy or worthy, that keeps us coming back to it again, and again, and again.", "https://images.bauerhosting.com/legacy/media/5e67/b5d6/d5e0/0a70/f606/0d1a/2-groundhog-day.jpg?auto=format&w=1200&q=80", "Groundhog Day" },
                    { 3, "When the first Paddington was on the way, early trailers didn't look entirely promising. Yet co-writer/director Paul King delivered a truly wonderful film bursting with joy, imagination, kindness, and just the odd hard stare from our beloved Peruvian bear. How was he going to follow that? By making one of the greatest sequels — nay, one of the best, most feel-good movies, period — of all time, naturally. Matching wits with Hugh Grant's moustache-twirlingly evil and deliciously outré washed-up actor Phoenix Buchanan, Paddington (Ben Whishaw) is on typically adorable form here as his search for a special present for his Great Aunt Lucy leads to all sorts of hilarious hijinks. Like all great sequels, this one takes everything that made the first so good and builds on it, dialing up the spectacle, the silliness, and the emotional stakes. The result is as sweet as marmalade.", "https://images.bauerhosting.com/legacy/media/5e1a/1bb7/d69f/1cb9/e380/fb8f/51-paddington-2.jpg?auto=format&w=1200&q=80", "Paddington 2" },
                    { 4, "Jean-Pierre Jeunet's fourth feature – his second as a solo artist divorced from Marc Caro – saw the Delicatessen, The City of Lost Children and Alien: Resurrection filmmaker leave behind the overwhelming darkness of his earlier works and step out into the glorious sunshine of Amélie's whimsical fantasy Paris. Sure, a cynic could read the film as the story of Audrey Tautou's monomaniacal title character's relentless, somewhat stalkerish pursuit of the hapless Nino (Matthieu Kassovitz) around Montmartre's dream-like cityscape. But this one isn't for the cynics — it's a tribute to the daydreamers of this world. It's a sweet, nostalgic, sentimental, beautifully sunny, unforcedly quirky romantic comedy played out amidst a veritable visual fantasia that only Jeunet could have conceived. Amélie will always be on our list of things we like.", "https://images.bauerhosting.com/legacy/media/5e1d/f8e8/d69f/1c28/ec81/1133/31-amelie.jpg?auto=format&w=1200&q=80", "Amelie" },
                    { 5, "A perfect meeting of two creative forces' artistic sensibilities, the Coen brothers' adaptation of Cormac McCarthy's literary great sees the directorial duo imbue the existentialism of McCarthy's book with their signature brand of dark and violent filmmaking. The result is a tense, slow, and mysterious take on the chase movie format, lensed immaculately by legendary DP Roger Deakins. It's also a film that thoughtfully considers the question of how — or even if — good people can ever hope to deal with a world that's entirely gone to shit. And lest we forget, this was the movie that gave us Javier Bardem's cold-blooded sociopathic killer Anton Chigurh, a villain so terrifying that Hollywood has scarcely been able to resist casting Bardem as the go-to bad guy ever since.", "https://images.bauerhosting.com/legacy/media/5e20/987c/ec7e/5492/ffd5/9229/12-no-country-for-old-men.jpg?auto=format&w=1200&q=80", "No Country For Old Men" },
                    { 6, "A high school drama with a time-travelling, tangential universe-threading, sinister rabbit-featuring twist, Richard Kelly's deliberately labyrinthine opus was always destined for cult classic status. A certifiable flop upon its theatrical release, Kelly's film was one of the early beneficiaries of physical media's move to DVD, with the movie gaining a fandom in film obsessives who could pause, play, and skip back and forth through it at will. Any attempt to synopsise the movie is a fool's errand, but there's more than a hint of It's A Wonderful Life in the way we see Donnie (Jake Gyllenhaal, in a star-making turn) experiencing how the world would be worse off if he survives the jet engine that mysteriously crashes through his bedroom. That the film, with all its heavy themes and brooding atmosphere, manages to eventually land on a note of overwhelming optimism is a testament to Kelly's mercurial moviemaking. A mad world (mad world) Donnie Darko's may be, but it's also one that continues to beguile and fascinate as new fans find themselves obsessed with uncovering its mysteries.", "https://images.bauerhosting.com/legacy/media/5f1a/c758/2c0a/701d/e670/10ca/27-donnie-darko.jpg?auto=format&w=1200&q=80", "Donnie Darko" },
                    { 7, "With Scott Pilgrim Vs. The World, Edgar Wright leaned all the way into the things that make his directorial style so singular — excellent needle drops, a poppy visual palette, whip-pans and whip-smart wit — in order to do Bryan Lee O'Malley's beloved graphic novels justice. Michael Cera is on peak socially awkward Cera form here as the eponymous put-upon protagonist who's forced to face his new girlfriend's (Mary Elizabeth Winstead) seven evil exes in a series of increasingly wild face-offs. But it's the film's extraordinarily stacked ensemble (Chris Evans! Brie Larson! Anna Kendrick! Aubrey Plaza!), impressive mixed-media aesthetics, and endless pool of iconic quotes and playlist-essential tunes that cement it as one of Wright's most memorable. This is good garlic bread.", "https://images.bauerhosting.com/legacy/media/5f34/0c56/b138/cbc2/3f04/3c09/scott-pilgrim-main.jpg?auto=format&w=1200&q=80", "Scott Pilgrim Vs. The World" },
                    { 8, "In some ways, Luc Besson's first English-language movie is a spiritual spin-off: after all, isn't Jean Reno's eponymous hitman just Nikita's Victor The Cleaner renamed and fleshed out? In all seriousness though, Besson's film — which sees Reno's titular contract killer caught up in an unlikely coming-of-age tale after his next-door neighbours wind up on the wrong side of a DEA sting — is very much its own beast. Inarguably, its greatest strength however isn't Reno, or even Gary Oldman's unhinged baddie Stansfield, but a very young Natalie Portman, who delivers a luminous, career-creating performance as vengeful 12-year-old Mathilda. Despite some of the ickiness inherent in the relationship the film presents between a middle-aged man and a pre-teen girl, Portman's phenomenal performance helps augment an unlikely kinship that winds up being deeply affecting to watch.", "https://images.bauerhosting.com/legacy/media/619d/5ed4/5165/4393/173b/793d/IMG_0294.jpeg?auto=format&w=1200&q=80", "Léon: The Professional" },
                    { 9, "If you're going to wrap up your tenure as one of the most loved superhero icons in fiction, it's hard to think of a better way than how Hugh Jackman — under the direction of a never-better James Mangold — punched out on the time clock of playing Wolverine. Set in a dark near-future world where an aging Logan is caring for a mentally unstable Professor Xavier (Patrick Stewart) and getting mixed up yet again with some very dangerous people, Logan takes cues from Western greats such as Shane as Wolvie wrestles with his mortality and history of violence. A truly original superhero tale that is mournful without being morbid, Mangold's mutant masterwork is the perfect end to Logan's story (an ending, it has to be noted, given a rousing yet respectful encore in Deadpool & Wolverine).", "https://images.bauerhosting.com/empire/2023/09/Logan.jpg?auto=format&w=1200&q=80", "Logan" },
                    { 10, "After his directorial debut Piranha II: Flying Killers fell on its face, James Cameron could've been forgiven for calling it quits on a filmmaking career in Hollywood. Instead, he made The Terminator — and the rest, as they say, is history (which you can read about in detail in our ultimate interview on the movie with Cameron himself). Shot on a $6 million budget, Cameron's sophomore feature may crib a little from Michael Crichton's Westworld and Harlan Ellison's Outer Limits episode 'Soldier', but its action — which revolves around Arnold Schwarzenegger's instantly iconic shot-gun-toting, shades-rocking, time-travelling cyborg killer — is, outside of Cameron's own oeuvre since, without comparison. Made with all the relentless tension of a slasher (after all, what is Arnie's Terminator if not Michael Myers in leathers?) and the kinetic thrills of a balls-to-the-wall blockbuster, nothing has been the same since the T-800 told Linda Hamilton's Sarah Connor \"Come with me if you want to live”.", "https://images.bauerhosting.com/empire/2024/11/the-terminator-2.jpg?auto=format&w=1200&q=80", "The Terminator" }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "MovieActorId", "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 2, 2 },
                    { 4, 5, 2 },
                    { 5, 2, 3 },
                    { 6, 1, 3 },
                    { 7, 4, 4 },
                    { 8, 5, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_MoviesMovieId",
                table: "ActorMovie",
                column: "MoviesMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_MovieId",
                table: "MovieActors",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieMovieRating_MoviesMovieId",
                table: "MovieMovieRating",
                column: "MoviesMovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieMovieRating");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "MovieRatings");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
