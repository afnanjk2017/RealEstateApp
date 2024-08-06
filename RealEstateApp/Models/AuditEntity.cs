﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class AuditEntity<TKey>
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; set; }

        /// <summary>
        /// Gets or sets the CreationDatetime.
        /// </summary>
        public DateTime? CreationDatetime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the CreatedBy.
        /// </summary>
       

        /// <summary>
        /// Gets or sets the LastEditDatetime.
        /// </summary>
        public DateTime? LastEditDatetime { get; set; }

        /// <summary>
        /// Gets or sets the LastEditBy.
        /// </summary>
       

        /// <summary>
        /// Gets or sets the DeletedDateTime.
        /// </summary>
        public DateTime? DeletedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the IsDeleted
        /// Gets or sets a value indicating whether IsDeleted..
        /// </summary>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the DeletedBy.
        /// </summary>
       
    
    }
}
