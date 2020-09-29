using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MLeagueManager2.Repo.magicleague
{
    public partial class magicleagueContext : DbContext
    {

        public magicleagueContext(DbContextOptions<magicleagueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BracketedGames> BracketedGames { get; set; }
        public virtual DbSet<GamePlayers> GamePlayers { get; set; }
        public virtual DbSet<League> League { get; set; }
        public virtual DbSet<LeagueGames> LeagueGames { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=OctopusSpy@82;database=magicleague");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BracketedGames>(entity =>
            {
                entity.ToTable("bracketed_games");

                entity.HasIndex(e => e.GameId)
                    .HasName("gid_idx");

                entity.Property(e => e.BracketedGamesId).HasColumnName("bracketed_gamesID");

                entity.Property(e => e.BracketMatch).HasColumnName("bracket_match");

                entity.Property(e => e.BracketRound).HasColumnName("bracket_round");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.BracketedGames)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bgid");
            });

            modelBuilder.Entity<GamePlayers>(entity =>
            {
                entity.HasKey(e => e.GamePlayerId)
                    .HasName("PRIMARY");

                entity.ToTable("game_players");

                entity.HasIndex(e => e.GameId)
                    .HasName("GID_idx");

                entity.HasIndex(e => e.TeamId)
                    .HasName("TID_idx");

                entity.Property(e => e.GamePlayerId).HasColumnName("game_playerID");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GamePlayers)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("GID");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.GamePlayers)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("TID");
            });

            modelBuilder.Entity<League>(entity =>
            {
                entity.ToTable("league");

                entity.HasIndex(e => e.LeagueAdmin)
                    .HasName("LAdmin_idx");

                entity.HasIndex(e => e.LeagueId)
                    .HasName("league_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.LeagueId).HasColumnName("league_ID");

                entity.Property(e => e.DeckRules).HasColumnName("deck_rules");

                entity.Property(e => e.GamePlayerMax).HasColumnName("game_player_max");

                entity.Property(e => e.LeagueAdmin).HasColumnName("league_admin");

                entity.Property(e => e.LeagueEnd).HasColumnName("league_end");

                entity.Property(e => e.LeagueGameMax).HasColumnName("league_game_max");

                entity.Property(e => e.LeagueName)
                    .HasColumnName("league_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LeagueStart).HasColumnName("league_start");

                entity.Property(e => e.LeagueYear)
                    .HasColumnName("league_year")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.LeagueAdminNavigation)
                    .WithMany(p => p.League)
                    .HasForeignKey(d => d.LeagueAdmin)
                    .HasConstraintName("LAdmin");
            });

            modelBuilder.Entity<LeagueGames>(entity =>
            {
                entity.HasKey(e => e.GameId)
                    .HasName("PRIMARY");

                entity.ToTable("league_games");

                entity.HasIndex(e => e.GameLoser)
                    .HasName("GLoser_idx");

                entity.HasIndex(e => e.GameWinner)
                    .HasName("GWinner_idx");

                entity.HasIndex(e => e.LeagueId)
                    .HasName("LID_idx");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.BracketParent1)
                    .HasColumnName("bracket_parent1")
                    .HasColumnType("int(10) unsigned zerofill");

                entity.Property(e => e.BracketParent2)
                    .HasColumnName("bracket_parent2")
                    .HasColumnType("int(10) unsigned zerofill");

                entity.Property(e => e.GameDate).HasColumnName("game_date");

                entity.Property(e => e.GameLoser).HasColumnName("game_loser");

                entity.Property(e => e.GameRound)
                    .HasColumnName("game_round")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.GameWinner).HasColumnName("game_winner");

                entity.Property(e => e.IsBracketed)
                    .HasColumnName("is_bracketed")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.LeagueId).HasColumnName("league_id");

                entity.HasOne(d => d.GameLoserNavigation)
                    .WithMany(p => p.LeagueGamesGameLoserNavigation)
                    .HasForeignKey(d => d.GameLoser)
                    .HasConstraintName("GLoser");

                entity.HasOne(d => d.GameWinnerNavigation)
                    .WithMany(p => p.LeagueGamesGameWinnerNavigation)
                    .HasForeignKey(d => d.GameWinner)
                    .HasConstraintName("GWinner");

                entity.HasOne(d => d.League)
                    .WithMany(p => p.LeagueGames)
                    .HasForeignKey(d => d.LeagueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GLID");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => e.TeamId)
                    .HasName("PRIMARY");

                entity.ToTable("teams");

                entity.HasIndex(e => e.LeagueId)
                    .HasName("LID_idx");

                entity.HasIndex(e => e.TeamOwner)
                    .HasName("TOwner_idx");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.LeagueId).HasColumnName("league_id");

                entity.Property(e => e.LeaguePos).HasColumnName("league_pos");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasColumnName("team_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TeamOwner).HasColumnName("team_owner");

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("LID");

                entity.HasOne(d => d.TeamOwnerNavigation)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.TeamOwner)
                    .HasConstraintName("TOwner");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.CanLeagueadmin)
                    .HasColumnName("can_leagueadmin")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.IsSysadmin)
                    .HasColumnName("is_sysadmin")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .HasColumnName("user_email")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("user_ name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
