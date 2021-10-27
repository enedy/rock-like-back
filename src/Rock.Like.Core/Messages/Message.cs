﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rock.Like.Core.Messages
{
    public abstract class Message
    {
        [NotMapped]
        public string MessageType { get; protected set; }
        [NotMapped]
        public Guid AggregateId { get; protected set; }

        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}
