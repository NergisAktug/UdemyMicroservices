// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace FreeCourse.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog"){Scopes={"catalog_fullpermission"}},
            new ApiResource("photo_stock_catalog"){Scopes={"photo_stock_fullpermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.OpenId(),//sub 
                       new IdentityResources.Profile(),
                       new IdentityResource(){Name="roles",DisplayName="Roles",Description="User roles",UserClaims=new []{"role" } }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission","Full access for Catalog API"),
                new ApiScope("photo_stock_fullpermission","Full access for Photo API"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
               new Client
               {
                   ClientName="Asp.Net Core MVC",
                   ClientId="WebMvcClient",
                   ClientSecrets={new Secret("secret".Sha256())},
                   AllowedGrantTypes=GrantTypes.ClientCredentials,
                   AllowedScopes={ "catalog_fullpermission", "photo_stock_fullpermission",IdentityServerConstants.LocalApi.ScopeName }
               },
               new Client
               {
                   ClientName="Asp.Net Core MVC",
                   ClientId="WebMvcClientForUser",
                   AllowOfflineAccess=true,
                   ClientSecrets={new Secret("secret".Sha256())},
                   AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,//Token donerken aynı zamanda refres token 'da donuldugu icin ResourceOwnerPasswordAndClientCredentials'ı kullanmadık
                  //İzin verilen datalar AllowedScopes alanına yazılır
                   AllowedScopes={IdentityServerConstants.StandardScopes.Email,
                         IdentityServerConstants.StandardScopes.OpenId, //OpenId, kullanıcının Id'si demek
                         IdentityServerConstants.StandardScopes.Profile,
                         IdentityServerConstants.StandardScopes.OfflineAccess,IdentityServerConstants.LocalApi.ScopeName,"roles"},//offline oldugu zaman erisim icin ekledik
                   AccessTokenLifetime=1*60*60, //Access token'nın gecerliligi 1 saat
                   RefreshTokenExpiration=TokenExpiration.Absolute,
                   AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                   RefreshTokenUsage=TokenUsage.ReUse
                   
               }

                 /*
                  Herbir token dondugumde aynı zamanda refresh token'da donebilmek istiyorum.OfflineAccess'ın olayı şu;
                  refresh token eğer elimizde varsa o anda login omazsa bile, siz kullanıcı adına refresh token gonderip, tekrar 
                 bir token elde edebiliriz.O yüzden ismi offline yani kullanıcı offline olsa dahi kullanıcı adına elimizdeki 
                 refresh token ile beraber yeni bir token alabiliriz. Eğer OfflineAccess'i kaldırısak elimizde refresh token olmazsa
                 yeni bir token almak istediğimde kullanıcıdan mutlaka E-mail ve password almak zorunda kalırız.O zaman bu şuna denk geliyor;
                 eğer elimizde refresh token yoksa ve mevcut token'nın omrü dolarsa 1 saaat sonra, ben kullanıcıyı tekrar login ekranına
                 döndürmek zorunda kalırız.Ve kullanıcı bu bilgileri girdikten sonra tekrar token talebinde bulunulur.Burada 2 çözüm şekli vardır;
                 1-)Ya aldıgımız access token'nın omru uzatılır.Ki bu iyi birşey değil.Örneğin bu token için geçerlilik suresi 60 gün olur.
                 60 gun sonra kullanıcı tekrar login ekranına döner.
       
                  
                  2-)Ama elimizde bir refresh token olursa , access token'nın omru 1 saat yaparız.Refresh token'nın ömrünü 60 gün yaparız.
                 Eğer elimizdeki mevcut token'nın ömrü dolarsa, cookide'de tuttuğumuz bir refresh token var; hiç kullanıcıya hissetirmeden 
                 access token'a istek yaptık 401 aldık diyelim.Refresh token ile git Identity Server'dan yeni bir token al. Bu işlem kullanıcı
                 hangi mikroserviste çalışıyorsa orada çalışmaya devam eder.Kullanıcıyı hiç login ekranına döndürmeden buna devam eder.
                  */



            };
    }
}