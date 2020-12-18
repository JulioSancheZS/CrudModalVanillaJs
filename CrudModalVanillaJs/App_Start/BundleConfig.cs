﻿using System.Web;
using System.Web.Optimization;

namespace CrudModalVanillaJs
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/Index").Include(
                        "~/Scripts/Index.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));
            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bulma.css",
                      "~/Content/site.css"));
        }
    }
}