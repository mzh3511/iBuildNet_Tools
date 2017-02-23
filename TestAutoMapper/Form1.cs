﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using AutoMapper;
using TestAutoMapper;

namespace TestAutoMapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderDto>());
        }

        private void AA(IMapperConfigurationExpression cfg)
        {
            cfg.
        }

        public class TweetContractProfile : Profile
        {
            public TweetContractProfile()
            {
                CreateMap<XElement, ITweetContract>()
                .ForMember(
                    dest => dest.Id,
                    options => options.ResolveUsing(AA)
                        .FromMember(source => source.Element("id")))
                .ForMember(
                    dest => dest.Name,
                    options => options.ResolveUsing<XElementResolver<string>>()
                        .FromMember(source => source.Element("user")
                            .Descendants("name").Single()))
                .ForMember(
                    dest => dest.UserName,
                    options => options.ResolveUsing<XElementResolver<string>>()
                        .FromMember(source => source.Element("user")
                            .Descendants("screen_name").Single()))
                .ForMember(
                    dest => dest.Body,
                    options => options.ResolveUsing<XElementResolver<string>>()
                        .FromMember(source => source.Element("text")))
                .ForMember(
                    dest => dest.ProfileImageUrl,
                    options => options.ResolveUsing<XElementResolver<string>>()
                        .FromMember(source => source.Element("user")
                            .Descendants("profile_image_url").Single()))
                .ForMember(
                    dest => dest.Created,
                    options => options.ResolveUsing<XElementResolver<string>>()
                        .FromMember(source => source.Element("created_at")));
            }
        }
    }
}
