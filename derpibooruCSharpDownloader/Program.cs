using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.History;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using derpibooruCSharpDownloader.Database;
using derpibooruCSharpDownloader.Database.Entity;
using Newtonsoft.Json;

namespace derpibooruCSharpDownloader
{
    public static class Program
    {
        public static Downloader Downloader { get; set; } = new Downloader();

        public static OfflineBrowser OfflineBrowser { get; set; } = new OfflineBrowser();
        public static Form1 Form { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Configuration.LoadConfig("config.ini");
            CreateAutoMapper();
            DoMigration();
            //DoDb();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form = new Form1(Downloader, OfflineBrowser);
            Application.Run(Form);
        }

        private static void CreateAutoMapper()
        {
            Mapper.CreateMap<Search, DerpyImage>()
                .ForMember(x => x.Id, src => src.MapFrom(x => x.id_number))
                .ForMember(x => x.DerpyImageId, src => src.MapFrom(x => x.id_number))
                .ForMember(x => x.IdHash, src => src.MapFrom(x => x.id))
                .ForMember(x => x.CreatedAt, src => src.MapFrom(x => x.created_at))
                .ForMember(x => x.UpdatedAt, src => src.MapFrom(x => x.updated_at))
                .ForMember(x => x.FileName, src => src.MapFrom(x => x.file_name))
                .ForMember(x => x.Description, src => src.MapFrom(x => x.description))
                .ForMember(x => x.Uploader, src => src.MapFrom(x => x.uploader))
                .ForMember(x => x.Image, src => src.MapFrom(x => x.image))
                .ForMember(x => x.Score, src => src.MapFrom(x => x.score))
                .ForMember(x => x.Upvotes, src => src.MapFrom(x => x.upvotes))
                .ForMember(x => x.Downvotes, src => src.MapFrom(x => x.downvotes))
                .ForMember(x => x.Favourites, src => src.MapFrom(x => x.faves))
                .ForMember(x => x.CommentCount, src => src.MapFrom(x => x.comment_count))
                .ForMember(x => x.Tags, src => src.MapFrom(x => x.tags))
                .ForMember(x => x.Width, src => src.MapFrom(x => x.width))
                .ForMember(x => x.Height, src => src.MapFrom(x => x.height))
                .ForMember(x => x.AspectRatio, src => src.MapFrom(x => x.aspect_ratio))
                .ForMember(x => x.OriginalFormat, src => src.MapFrom(x => x.original_format))
                .ForMember(x => x.MimeType, src => src.MapFrom(x => x.mime_type))
                .ForMember(x => x.Sha512Hash, src => src.MapFrom(x => x.sha512_hash))
                .ForMember(x => x.OriginalSha512Hash, src => src.MapFrom(x => x.original_format))
                .ForMember(x => x.SourceUrl, src => src.MapFrom(x => x.source_url))
                .ForMember(x => x.License, src => src.MapFrom(x => x.license))
                .ForMember(x => x.IsRendered, src => src.MapFrom(x => x.is_rendered))
                .ForMember(x => x.IsOptimized, src => src.MapFrom(x => x.is_optimized));

            //Mapper.CreateMap<Search, DerpyImage>()
            //    .ForMember(x => x.Representations, src => src.);

            Mapper.CreateMap<Representations, DerpyRepresentation>()
                .ForMember(x => x.ThumbTiny, src => src.MapFrom(x => x.thumb_tiny))
                .ForMember(x => x.ThumbSmall, src => src.MapFrom(x => x.thumb_small))
                .ForMember(x => x.Thumb, src => src.MapFrom(x => x.thumb))
                .ForMember(x => x.Small, src => src.MapFrom(x => x.small))
                .ForMember(x => x.Medium, src => src.MapFrom(x => x.medium))
                .ForMember(x => x.Large, src => src.MapFrom(x => x.large))
                .ForMember(x => x.Tall, src => src.MapFrom(x => x.tall))
                .ForMember(x => x.Full, src => src.MapFrom(x => x.full));
        }

        private static void DoMigration()
        {
            var configuration = new Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            
            migrator.Update();
        }

        private static void DoDb()
        {
            using (var db = new DerpyDbContext())
            {
                
                db.DerpyImages.Add(new DerpyImage()
                {
                    Id = 0,
                    IdHash = "0",
                    Description = "Test"
                });
                db.SaveChanges();

                foreach (var blog in db.DerpyImages)
                {
                    Console.WriteLine(blog.Description);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
