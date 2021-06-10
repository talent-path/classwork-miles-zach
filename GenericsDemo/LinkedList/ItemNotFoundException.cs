﻿using System;
namespace LinkedList
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message) : base(message)
        {
        }

        public ItemNotFoundException(string message, Exception innerException) : base (message, innerException)
        {

        }
    }
}
