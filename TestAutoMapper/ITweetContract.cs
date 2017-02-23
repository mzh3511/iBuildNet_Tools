// Copyright (c)2016 Ranplan Co.
// All rights reserved.
// 
// Create and modify records:
// 1. 2016-10-26 16:35 Zhenhua Mao created.
// 
namespace TestAutoMapper
{
    public interface ITweetContract
    {
        ulong Id { get; set; }
        string Name { get; set; }
        string UserName { get; set; }
        string Body { get; set; }
        string ProfileImageUrl { get; set; }
        string Created { get; set; }
    }
}