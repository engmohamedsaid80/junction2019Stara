#pragma checksum "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd39e2d3b04f311c46a74ccf5f35c1eaa2795c1b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\_ViewImports.cshtml"
using D_STARA;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\_ViewImports.cshtml"
using D_STARA.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd39e2d3b04f311c46a74ccf5f35c1eaa2795c1b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f94621c9629f33945b0ad4bf2bed188fb9b8db8d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<StaraDomainModels.Model.Project>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "D-STARA";
    // Layout = "~/Views/Shared/_Layout-WithoutMenu.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"" charset=""utf-8"">

    var map;

    var myLat = 60;
    var myLong = 24;

    function ginitialize() {

        var myLatlng = new google.maps.LatLng(60, 24);
        var myOptions = {
            zoom: 10, center: myLatlng, panControl: false, mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(document.getElementById(""map_canvas""), myOptions);


        // var infoWindow = new google.maps.InfoWindow({ map: map });
        if (navigator.geolocation) {

            // loadBranches(32, 36);
            navigator.geolocation.getCurrentPosition(function (position) {
                var pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude

                };

                var marker = new google.maps.Marker({
                    position: pos,
                    map: map,
                    title: 'My Current Location!',
                    icon: '/STARA/im");
            WriteLiteral(@"ages/currentlocation.png'
                });

                // infoWindow.setPosition(pos);
                // infoWindow.setContent('Location found.');
                map.setCenter(pos);
                map.setZoom(10);

                myLat = pos.lat;
                myLong = pos.lng;

                //populate districts dropdown


                loadBranches(pos.lat, pos.lng);


            }, function () {
                loadBranches(60, 24);
                handleLocationError(true, """", map.getCenter());
            });
        } else {
            // Browser doesn't support Geolocation
            //alert(""*****"");
            loadBranches(60, 24);
            handleLocationError(false, """", map.getCenter());
        }


        function handleLocationError(browserHasGeolocation, error, pos) {

        }


    }

</script>



<script type=""text/javascript"" charset=""utf-8"">

    var rad = function (x) {
        return x * Math.PI / 180;
    };

    // ");
            WriteLiteral(@"calculates the distance between two locations in meters
    var getDistance = function (pLat1, pLong1, pLat2, pLong2) {
        var R = 6378137; // Earth’s mean radius in meter
        var dLat = rad(pLat2 - pLat1);
        var dLong = rad(pLong2 - pLong1);
        var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
            Math.cos(rad(pLat1)) * Math.cos(rad(pLat2)) *
            Math.sin(dLong / 2) * Math.sin(dLong / 2);
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
        var d = R * c;
        return d; // returns the distance in meter
    };

    var iw;
    var gmarkers = [];

    var longitudes1 = [];
    var latitudes1 = [];
    var locAddress1 = [];
    var locDesc1 = [];
    var locRegion1 = [];
    var locNames1 = [];
    var locPhones1 = [];



    function markerClick(i) {
        google.maps.event.trigger(gmarkers[i], ""click"");
    }


    function setBranches(longs, lats, address, descriptions, regions, names, phones) {


        try {
   ");
            WriteLiteral(@"         longitudes1 = JSON.parse(longs);
            latitudes1 = JSON.parse(lats);
            locRegion1 = JSON.parse(regions);
            locNames1 = JSON.parse(names);
            locPhones1 = JSON.parse(phones);
        } catch (e) {

        }

        try {
            locAddress1 = JSON.parse(address);
        } catch (e) {

        }

        try {
            locDesc1 = JSON.parse(descriptions);
        } catch (e) {

        }
    }

    //add branches locations on the map
    function loadBranches(curLat, curLong) {

        //var branches = """);
#nullable restore
#line 146 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\Home\Index.cshtml"
                     Write(ViewBag.Branches);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";

       // alert(""length: "" + branches);

        $(""#branchList"").empty();
        hideMarkers(map, gmarkers);
        map.setZoom(10);

        var sortedLocations = [];

        var longitudes = [];// = longitudes1;
        var latitudes = [];//latitudes1;
        var locAddress = [];//locAddress1;
        var locDesc = [];//locDesc1;
        var locRegion = [];//locRegion1;
        var locName = [];//locNames1;
        var locPhone = [];//locPhones1;

        var startDate = [];//locPhones1;
        var endDate = [];//locPhones1;



        //var myArray = [];
");
#nullable restore
#line 170 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\Home\Index.cshtml"
           foreach (var m in Model)
          {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            WriteLiteral("locName.push([\"");
#nullable restore
#line 172 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\Home\Index.cshtml"
                            Write(Html.Raw(m.ProjectId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"]);\r\n                ");
            WriteLiteral("longitudes.push([\"");
#nullable restore
#line 173 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\Home\Index.cshtml"
                               Write(m.Longitude);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"]);\r\n                ");
            WriteLiteral("latitudes.push([\"");
#nullable restore
#line 174 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\Home\Index.cshtml"
                              Write(m.Latitude);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"]);\r\n                ");
            WriteLiteral("locAddress.push([\"");
#nullable restore
#line 175 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\Home\Index.cshtml"
                               Write(m.Streetname);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"]);\r\n                ");
            WriteLiteral("locDesc.push([\"");
#nullable restore
#line 176 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\Home\Index.cshtml"
                            Write(m.Streetname);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"]);\r\n");
#nullable restore
#line 177 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\Home\Index.cshtml"
               // @:locRegion.push(["@m.BotLocation_Filters_Lvl_3Id"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            WriteLiteral("locPhone.push([\"");
#nullable restore
#line 178 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\Home\Index.cshtml"
                             Write(m.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"]);\r\n");
            WriteLiteral("         ");
            WriteLiteral("startDate.push([\"");
#nullable restore
#line 180 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\Home\Index.cshtml"
                       Write(m.StartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"]);\r\n         ");
            WriteLiteral("endDate.push([\"");
#nullable restore
#line 181 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\Home\Index.cshtml"
                     Write(m.EndTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"]);\r\n");
#nullable restore
#line 182 "D:\MyWork\junction\junction2019Stara\source\Web\D-STARA\Views\Home\Index.cshtml"


          }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        //alert(""length: "" + longitudes.length);

        var infoWindowContent = [];
        var mr = [];
       // alert(""2"");
        for (i = 0; i < longitudes.length; i++) {
            //if ($('.ddlRegionArea').find("":selected"").text() == 'All') {

                var distance = getDistance(myLat, myLong, latitudes[i], longitudes[i]); //curLat, curLong

            sortedLocations.push([distance, latitudes[i], longitudes[i], locAddress[i], locDesc[i], locRegion[i], locName[i], locPhone[i], startDate[i], endDate[i]]);
           // }
           // else {
             //   splittedValues = $('.ddlRegionArea').find("":selected"").val().split('-');
                //if (splittedValues[0] == locRegion[i]) {
                  //  var distance = getDistance(myLat, myLong, latitudes[i], longitudes[i]);
                //    sortedLocations.push([distance, latitudes[i], longitudes[i], locAddress[i], locDesc[i], locRegion[i], locName[i], locPhone[i]]);
              //  }
            //}
        ");
            WriteLiteral(@"    //sortedLocations.push([distance, latitudes[i], longitudes[i], locAddress[i], locDesc[i], locRegion[i], locName[i], locPhone[i]]);
        }

        sortedLocations.sort(function (a, b) { return (a[0] < b[0] ? -1 : (a[0] > b[0] ? 1 : 0)); });
       // alert(""3"");
        for (i = 0; i < sortedLocations.length; i++) {

            mr[i] = new google.maps.Marker({ position: new google.maps.LatLng(sortedLocations[i][1], sortedLocations[i][2]), map: map, icon: '/STARA/images/locationPin.png', title: sortedLocations[i][3].toString() });

            google.maps.event.addListener(mr[i], 'click', function () {

                var infoWindow = '<div class=""branchTooltip"" style=""overflow: hidden"" >' +
                    '<p>' + this.getTitle() + '</p> </div>';

                map.setZoom(14);
                map.setCenter(this.getPosition());
                if (iw) iw.close();
                iw = new google.maps.InfoWindow({
                    content: infoWindow,
                    max");
            WriteLiteral(@"Width: 350
                });
                iw.open(map, this);


                google.maps.event.addListener(iw, 'domready', function () {

                    // Reference to the DIV that wraps the bottom of infowindow
                    var iwOuter = $('.gm-style-iw');

                    iwOuter.css({ 'background-color': '#046d5a !important', 'overflow': 'hidden' });

                    //iwOuter.parent().css({ 'background-color': '#046d5a !important', 'overflow': 'hidden' });

                    var iwBackground = iwOuter.prev();
                    // Removes white background DIV
                    iwBackground.children(':nth-child(4)').css({ 'display': 'none', 'overflow': 'hidden', 'background-color': '#046d5a !important ' });

                    /* Since this div is in a position prior to .gm-div style-iw.
                     * We use jQuery and create a iwBackground variable,
                     * and took advantage of the existing reference .gm-style-iw for the previ");
            WriteLiteral(@"ous div with .prev().
                    */


                });



            });
            gmarkers.push(mr[i]);

            var link = '<div class=""branchWrapper""><a href=""javascript:markerClick(' + i + ');"" Id=' + i + '><h3>Project No:' + sortedLocations[i][6] +
                '</h3><p>' + sortedLocations[i][3] + '</p>' +
                '<span class=""locationIcon glyphicon glyphicon-map-marker""></span></a> ' +
                '<dl><dt>' + 'Start Date: </dt><dd>' + sortedLocations[i][8] + '</dd> </dl><br/> <br/>' +
                '<dl><dt>' + 'End Date: </dt><dd>' + sortedLocations[i][9] + '</dd> </dl><br/> <br/>' +
                ' <dl><dt> <a href=""https://www.google.com.sa/maps/&#64;' + sortedLocations[i][1] + ',' + sortedLocations[i][2] + ',15z"" target=""_blank"">' + 'Navigate </a> </dl></dt></div>';

           $(""#branchList"").append(link);
        }

        //alert(""Sorted locations: "" + sortedLocations.length);


    }


    function hideMarkers(map, markers) {
");
            WriteLiteral("        /* Remove All Markers */\r\n        while (markers.length) {\r\n            markers.pop().setMap(null);\r\n        }\r\n    }\r\n\r\n\r\n");
            WriteLiteral("\r\n\r\n\r\n\r\n</script>\r\n\r\n<script async defer\r\n        src=\"https://maps.googleapis.com/maps/api/js?key=AIzaSyAcrO1KxCsPo3HkqADuROutVeeJzzRzqIo&callback=ginitialize\">\r\n</script>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        //Filter Cities by Country
        document.getElementById(""CountryName"").addEventListener(""change"", function (e) {
            var country = document.getElementById(""CountryName"");
            var selectedcountryname = country.options[country.selectedIndex].text;
            var selectedcountry = country.options[country.selectedIndex].value;
            var cities = document.getElementById(""CityName"");
            var citycount = document.getElementById(""CityName"").options.length;
            if (selectedcountryname != ""All"") {

                for (var i = 0; i < citycount; i++) {
                    splittedValues = cities.options[i].value.split('-');
                    if (splittedValues[1] == selectedcountry) {
                        cities[i].style.display = ""block"";
                    }
                    else {
                        cities[i].style.display = ""none"";
                    }

                }
            }
            else {
            ");
                WriteLiteral(@"    for (var i = 0; i < citycount; i++) {
                    cities[i].style.display = ""block"";
                }
            }

        }, false);

        //Filter Districts By City
        document.getElementById(""CityName"").addEventListener(""change"", function (e) {
            var city = document.getElementById(""CityName"");
            var selectedcityname = city.options[city.selectedIndex].text;
            var selectedcity = city.options[city.selectedIndex].value;
            splittedValuesCity = selectedcity.split('-');
            var districts = document.getElementById(""DistrictName"");
            var districtcount = document.getElementById(""DistrictName"").options.length;
            if (selectedcityname != ""All"") {

                for (var i = 0; i < districtcount; i++) {
                    splittedValues = districts.options[i].value.split('-');
                    if (splittedValues[1] == splittedValuesCity[0]) {
                        districts[i].style.display = ""block"";
");
                WriteLiteral(@"                    }
                    else {
                        districts[i].style.display = ""none"";
                    }

                }
            }
            else {
                for (var i = 0; i < districtcount; i++) {
                    districts[i].style.display = ""block"";
                }
            }

        }, false);
    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n\r\n<div class=\"mapWrapper\">\r\n    <div class=\"filterWrapper\">\r\n        <div class=\"row\">\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n            <div class=\"col-lg-3 col-md-3 col-sm-12\">\r\n                <label class=\"inputLabel\">Projects</label>\r\n");
            WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral(@"
    <div class=""branchList"">
        <div class=""nano"">
            <div class=""nano-content"" id=""branchList"">

                <div class=""branchWrapper"">

                </div>
            </div>
        </div>
    </div>;
    <div id=""map_canvas"" class=""map"" style=""width:100%;height:850px; position:relative;top:0;left:0;z-index:1""></div>
</div>



");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<StaraDomainModels.Model.Project>> Html { get; private set; }
    }
}
#pragma warning restore 1591
