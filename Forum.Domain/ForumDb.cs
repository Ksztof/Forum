﻿using Forum.Domain.Models.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain
{
    public class ForumDb : IdentityDbContext
        <
        WebAppUser, WebAppRole, string,
        WebAppUserClaims, WebAppUserRole, WebAppUserLogin,
        WebAppRoleClaim, WebAppUserToken
        >
    {
        public ForumDb() // Tworzymy 1 pusty konstruktor
        {

        }

        public ForumDb(DbContextOptions<ForumDb> options) : base(options) // Tworzymy konstruktor przekazując mu 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Tworze plik json
            // pobieram connection stringi
            // przekazuje connection string do konfiguracji
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID =postgres;Password=\"haslo1234\";Server=localhost;Port=5432;Database=Forum;");
            }
        }

        //definiujesz połaczenia miedzy tablekami oraz nakładasz ograniczenia na tabele
        protected override void OnModelCreating(ModelBuilder modelBuilder) // nadpisujemy metodę z dbcontext
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Question>()
                .HasOne<AppUser>(q => q.AppUser)
                .WithMany(a => a.Questions)
                .HasForeignKey(q => q.AppUserId);

            modelBuilder.Entity<Answer>()
                .HasOne<AppUser>(an => an.AppUser)
                .WithMany(a => a.Answers)
                .HasForeignKey(an => an.AppUserId);

            modelBuilder.Entity<Answer>()
                .HasOne<Question>(an => an.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(an => an.QuestionId);

            modelBuilder.Entity<CommentToAnswer>()
                .HasOne<Answer>(an => an.Answer)
                .WithMany(cta => cta.CommentsToAnswer)
                .HasForeignKey(an => an.AnswerId);

            modelBuilder.Entity<CommentToComment>()
                .HasOne<CommentToAnswer>(an => an.CommentToAnswer)
                .WithMany(cta => cta.Comments)
                .HasForeignKey(an => an.CommentToAnswerId);

            modelBuilder.Entity<AppUser>()
                .HasOne<UserProfile>(a => a.UserProfile)
                .WithOne(up => up.AppUser)
                .HasForeignKey<UserProfile>(up => up.AppUserId);

            modelBuilder.Entity<QuestionTag>().HasKey(qt => new { qt.QuestionId, qt.TagId });

            modelBuilder.Entity<CommentToAnswer>()
             .HasOne<Question>(cta => cta.Question)
             .WithMany(q => q.CommentsToAnswer)
             .HasForeignKey(cta => cta.QuestionId);

            this.SeedBaseData(modelBuilder); // wstrzykuje dane 


        }


        private void SeedBaseData(ModelBuilder modelBuilder)
        {
            // dodaje dane podstawowoe
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<CommentToAnswer> CommentsToAnswer { get; set; }
        public virtual DbSet<CommentToComment> CommentsToComment { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionTag> QuestionTags { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        /**
         * Web App login system
         */
        public virtual DbSet<WebAppUser> WebAppUsers { get; set; }
        public virtual DbSet<WebAppRole> WebAppRoles { get; set; }
        public virtual DbSet<WebAppRoleClaim> WebAppRoleClaims { get; set; }
        public virtual DbSet<WebAppUserClaims> WebAppUsersClaims { get; set; }
        public virtual DbSet<WebAppUserLogin> WebAppUsersLogins { get; set; }
        public virtual DbSet<WebAppUserRole> WebAppUsersRoles { get; set; }
        public virtual DbSet<WebAppUserToken> WebAppUsersTokens { get; set; }
    }
}


/*
 1. Jeden użytkownik może zadawać wiele pytań
 2. Jeden uzytkownik może dać wiele odpowiedzi do pytania 
 3. Jedno pytanie może mieć wiele komentarzy
 4. Jeden komentarz może mieć wiele komentarzy do komentarza 
 */