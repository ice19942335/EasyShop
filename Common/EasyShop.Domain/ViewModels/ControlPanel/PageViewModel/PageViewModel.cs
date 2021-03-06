﻿using System;

namespace EasyShop.Domain.ViewModels.ControlPanel.PageViewModel
{
    public class PageViewModel
    {
        public int PageNumber { get; }

        public int TotalPages { get; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
