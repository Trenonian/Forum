using System;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace forum.Models
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            db.Database.Migrate();

            #region Users: admin, lumberjack, FlowerPower, jimmy samurai, MarySue
            #region admin : Admin123!
            var admin = await userManager.FindByNameAsync("admin");
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "amon-ra@sbcglobal.net",
                    Signature = "Adeptus Mechanicus"
                };
                await userManager.CreateAsync(admin, "Admin123!");
                
                await userManager.AddClaimAsync(admin, new Claim("IsAdmin", "true"));
            }
            #endregion
            #region lumberjack : Lumberjack123!
            var lumber = await userManager.FindByNameAsync("lumberjack");
            if (lumber == null)
            {
                lumber = new ApplicationUser
                {
                    UserName = "lumberjack",
                    Email = "mountainman@fake.com",
                    Signature = "And my axe!"
                };
                await userManager.CreateAsync(lumber, "Lumberjack123!");
            }
            #endregion
            #region FlowerPower : FlowerPower123!
            var flower = await userManager.FindByNameAsync("FlowerPower");
            if (flower == null)
            {
                flower = new ApplicationUser
                {
                    UserName = "FlowerPower",
                    Email = "daisy@fake.com",
                    Signature = "Flowers are the best."
                };
                await userManager.CreateAsync(flower, "FlowerPower123!");
            }
            #endregion
            #region jimmy : Jimmy123!
            var jimmy = await userManager.FindByNameAsync("jimmy");
            if (jimmy == null)
            {
                jimmy = new ApplicationUser
                {
                    UserName = "jimmy",
                    Email = "jimmy@fake.com"
                };
                await userManager.CreateAsync(jimmy, "Jimmy123!");
            }
            #endregion
            #region samurai : Samurai123!
            var samurai = await userManager.FindByNameAsync("samurai");
            if (samurai == null)
            {
                samurai = new ApplicationUser
                {
                    UserName = "samurai",
                    Email = "blade@fake.com",
                    Signature = "The perfect sword."
                };
                await userManager.CreateAsync(samurai, "Samurai123!");
            }
            #endregion
            #region MarySue : MarySue123!
            var mary = await userManager.FindByNameAsync("MarySue");
            if (mary == null)
            {
                mary = new ApplicationUser
                {
                    UserName = "MarySue",
                    Email = "protagonist@fake.com",
                    Signature = "Everything is awesome!"
                };
                await userManager.CreateAsync(mary, "MarySue123!");
            }
            #endregion
            #region user template
            //#region user
            //var user = await userManager.FindByNameAsync("");
            //if (user == null)
            //{
            //    user = new ApplicationUser
            //    {
            //        UserName = "",
            //        Email = "@fake.com",
            //        Signature = ""
            //    };
            //    await userManager.CreateAsync(user, "");
            //}
            //#endregion
            #endregion
            #endregion
            #region Boards: HTML, CSS, CSharp, Javascript, Random
            List<Board> boards = new List<Board>() {
                #region HTML, CSS, CSharp, Javascript, Random
                new Board { Name = "HTML" },
                new Board { Name = "CSS" },
                new Board { Name = "CSharp" },
                new Board { Name = "Javascript" },
                new Board { Name = "Random" }
                #endregion
            };
            #endregion
            #region Check for and add Boards
            for (int i=0; i<boards.Count; i++)
            {
                var dbBoard = db.Boards.FirstOrDefault(b => b.Name == boards[i].Name);
                boards[i] = dbBoard ?? boards[i];
                if (dbBoard != boards[i])
                {
                    db.Boards.Add(boards[i]);
                }
            }
            db.SaveChanges();
            #endregion
            #region Posts
            List<Post> posts = new List<Post>()
            {
            #region Javascript : MarySue : Typescript is the best!
            new Post
            {
                ParentBoard = db.Boards.First(b => b.Name == "Javascript"),
                Title = "Typescript is the best!",
                Content = "I can't believe how much easier it makes everything, so nice.",
                Created = new DateTime(2015, 1, 1, 0, 0, 0),
                Creator = db.Users.First(u => u.UserName == "MarySue")
            },
            #endregion
            #region HTML : samurai : What does a span tag do?
            new Post
            {
                ParentBoard = db.Boards.First(b => b.Name == "HTML"),
                Title = "What does a span tag do?",
                Created = new DateTime(2015, 2, 1, 0, 0, 0),
                Creator = db.Users.First(u => u.UserName == "samurai")
            },
            #endregion
            #region CSS : lumberjack : Can you nest tags?
            new Post
            {
                ParentBoard = db.Boards.First(b => b.Name == "CSS"),
                Title = "Can you nest tags?",
                Content = "I've seen people do it but I can't get it to work.",
                Created = new DateTime(2015, 3, 1, 0, 0, 0),
                Creator = db.Users.First(u => u.UserName == "lumberjack")
            },
            #endregion
            #region CSharp : FlowerPower : Sample Data
            new Post
            {
                ParentBoard = db.Boards.First(b => b.Name == "CSharp"),
                Title = "Sample Data",
                Content = "It takes forever to populate the sample data...",
                Created = new DateTime(2015, 4, 1, 0, 0, 0),
                Creator = db.Users.First(u => u.UserName == "FlowerPower")
            },
            #endregion
            #region Random : jimmy : How do I know you are real?
            new Post
            {
                ParentBoard = db.Boards.First(b => b.Name == "Random"),
                Title = "How do I know you are real?",
                Content = "I think you're all robots",
                Created = new DateTime(2015, 5, 1, 0, 0, 0),
                Creator = db.Users.First(u => u.UserName == "jimmy")
            },
            #endregion
            #region Javascript : jimmy : loops
            new Post
            {
                ParentBoard = db.Boards.First(b => b.Name == "Javascript"),
                Title = "loops",
                Content = "when to use for loops vs while loops",
                Created = new DateTime(2016, 6, 1, 0, 0, 0),
                Creator = db.Users.First(u => u.UserName == "jimmy")
            },
            #endregion
            #region CSS : samurai : How do I select just the last element?
            new Post
            {
                ParentBoard = db.Boards.First(b => b.Name == "CSS"),
                Title = "How do I select just the last element?",
                Content = "like in a list",
                Created = new DateTime(2016, 7, 1, 0, 0, 0),
                Creator = db.Users.First(u => u.UserName == "samurai")
            },
            #endregion
            #region Random : MarySue : Favorite Color?
            new Post
            {
                ParentBoard = db.Boards.First(b => b.Name == "Random"),
                Title = "Favorite Color?",
                Content = "What is everyone's favorite color?",
                Created = new DateTime(2016, 8, 1, 0, 0, 0),
                Creator = db.Users.First(u => u.UserName == "MarySue")
            },
            #endregion
            #region HTML : lumberjack : Classes vs Ids
            new Post
            {
                ParentBoard = db.Boards.First(b => b.Name == "HTML"),
                Title = "Classes vs Ids",
                Content = "Maybe this is more of a CSS question, but should I use a style or an id if its the only element getting the style?",
                Created = new DateTime(2016, 9, 1, 0, 0, 0),
                Creator = db.Users.First(u => u.UserName == "lumberjack")
            },
            #endregion
            #region CSharp : FlowerPower : Access Modifiers
            new Post
            {
                ParentBoard = db.Boards.First(b => b.Name == "CSharp"),
                Title = "Access Modifiers",
                Content = "When should I use private? What about protected?",
                Created = new DateTime(2016, 10, 1, 0, 0, 0),
                Creator = db.Users.First(u => u.UserName == "FlowerPower")
            }
            #endregion
            #region Template: Board : User : Title
            //Post Ptemplate = new Post
            //{
            //    ParentBoard = context.Boards.First(b => b.Name == ""),
            //    Title = "",
            //    Content = "",
            //    Created = new DateTime(2016,,,,,),
            //    Creator = context.Users.First(u => u.UserName == "")
            //}
            #endregion
            };
            #endregion
            #region Check for and add Posts
            for (int i = 0; i < posts.Count; i++)
            {
                var dbPost = db.Posts.FirstOrDefault(p => p.Title == posts[i].Title);
                posts[i] = dbPost ?? posts[i];
                if (dbPost != posts[i])
                {
                    db.Posts.Add(posts[i]);
                }
            }
            db.SaveChanges();
            #endregion

            #region Comments
            List<Comment> comments = new List<Comment>()
            {
                #region lumberjack, My weekend is gone, Sample Data
                new Comment
                {
                    Creator = db.Users.First(u => u.UserName == "lumberjack"),
                    Content = "My weekend is gone, there is only sample data.",
                    ParentPost = db.Posts.First(p => p.Title == "Sample Data"),
                    Created = new DateTime(2015, 12, 1, 0, 0, 0)
                },
                #endregion
                #region MarySue, It wasn't so bad, Sample Data
                new Comment
                {
                    Creator = db.Users.First(u => u.UserName == "MarySue"),
                    Content = "It wasn't so bad",
                    ParentPost = db.Posts.First(p => p.Title == "Sample Data"),
                    Created = new DateTime(2015, 12, 1, 1, 0, 0)
                },
                #endregion
                #region jimmy, The worst, Sample Data
                new Comment
                {
                    Creator = db.Users.First(u => u.UserName == "jimmy"),
                    Content = "The worst.",
                    ParentPost = db.Posts.First(p => p.Title == "Sample Data"),
                    Created = new DateTime(2015, 12, 1, 2, 0, 0)
                },
                #endregion
                #region samurai, Through discipline, Sample Data
                new Comment
                {
                    Creator = db.Users.First(u => u.UserName == "samurai"),
                    Content = "Through discipline we grow stronger.",
                    ParentPost = db.Posts.First(p => p.Title == "Sample Data"),
                    Created = new DateTime(2015, 12, 1, 3, 0, 0)
                },
                #endregion
                #region Template: User, Content, PostOrComment
                //Comment Ctemplate = new Comment
                //{
                //    Creator = context.Users.First(u => u.UserName == ""),
                //    Content = "",
                //    Parent = context.Posts.First(p => p.Title == ""),
                //    Created = new DateTime(2015,,,,,)
                //};
                #endregion
            };
            #endregion

            #region Check for and add Comments
            for (int i = 0; i < comments.Count; i++)
            {
                var dbComment = db.Comments.FirstOrDefault(c => c.Content == comments[i].Content);
                comments[i] = dbComment ?? comments[i];
                if (dbComment != comments[i])
                {
                    db.Comments.Add(comments[i]);
                }
            }
            db.SaveChanges();
            #endregion
            #region Child Comments
            #region FlowerPower, What does that mean, Through discipline
            comments.Add(
                new Comment
                {
                    Creator = db.Users.First(u => u.UserName == "FlowerPower"),
                    Content = "What does that mean?!",
                    ParentPost = db.Posts.First(p => p.Title == "Sample Data"),
                    ParentComment = comments.First(c => c.Content == "Through discipline we grow stronger."),
                    Created = new DateTime(2015, 12, 1, 4, 0, 0)
                }
            );
            for (int i = 0; i < comments.Count; i++)
            {
                var dbComment = db.Comments.FirstOrDefault(c => c.Content == comments[i].Content);
                comments[i] = dbComment ?? comments[i];
                if (dbComment != comments[i])
                {
                    db.Comments.Add(comments[i]);
                }
            }
            db.SaveChanges();
            #endregion
            #region samurai, idk, What does that mean
            comments.Add(
                new Comment
                {
                    Creator = db.Users.First(u => u.UserName == "samurai"),
                    Content = "idk",
                    ParentPost = db.Posts.First(p => p.Title == "Sample Data"),
                    ParentComment = comments.First(c => c.Content == "What does that mean?!"),
                    Created = new DateTime(2015, 12, 1, 5, 0, 0)
                }
            );
            for (int i = 0; i < comments.Count; i++)
            {
                var dbComment = db.Comments.FirstOrDefault(c => c.Content == comments[i].Content);
                comments[i] = dbComment ?? comments[i];
                if (dbComment != comments[i])
                {
                    db.Comments.Add(comments[i]);
                }
            }
            db.SaveChanges();
            #endregion
            #endregion

            #region Non-admin sample users automatically upvote all comments made by non-admin sample users
            List<ApplicationUser> bots = db.Users
                .Where(u => 
                    u.UserName == "lumberjack" || 
                    u.UserName == "MarySue" || 
                    u.UserName == "jimmy" || 
                    u.UserName == "samurai" || 
                    u.UserName == "FlowerPower"
                ).Select(u => u).ToList();
            foreach (Comment comment in comments)
            {
                foreach (ApplicationUser bot in bots)
                {
                    Vote vote = db.Votes.FirstOrDefault(v => (v.Voter.Id == bot.Id) && (v.Target.Id == comment.Id));

                    if (vote == null)
                    {
                        db.Votes.Add(new Vote { Voter = bot, Target = comment, isUpVote = true });
                    }
                }
                comment.Score = comment.Votes.Where(v => v.isUpVote).Count() - comment.Votes.Where(v => v.isUpVote == false).Count();
            }
            db.SaveChanges();
            #endregion
            
        }

    }
}
