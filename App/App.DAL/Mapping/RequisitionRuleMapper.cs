using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapping
{
    public class RequisitionRuleMapper
    {
        public RequisitionRuleMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequisitionRule>().ToTable("TBL_RequisitionRule");
            modelBuilder.Entity<RequisitionRule>().HasKey(rule => rule.Id);

            modelBuilder.Entity<RequisitionRule>().Property(rule => rule.Id).HasColumnName("RequisitionRuleID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<RequisitionRule>().Property(rule => rule.RequisitionId).HasColumnName("RequisitionID").IsRequired();
            modelBuilder.Entity<RequisitionRule>().Property(rule => rule.AuthorizationState).HasColumnName("AuthorizationState").HasMaxLength(60).IsRequired();
            modelBuilder.Entity<RequisitionRule>().Property(rule => rule.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<RequisitionRule>().Property(rule => rule.Created).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<RequisitionRule>().Property(rule => rule.UpdatedBy).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<RequisitionRule>().Property(rule => rule.Updated).HasColumnName("Updated").IsRequired();

            modelBuilder.Entity<RequisitionRule>()
                .HasRequired(rule => rule.Requisition)
                .WithMany(requisition => requisition.Rules)
                .HasForeignKey(rule => rule.RequisitionId);
        }
    }
}
