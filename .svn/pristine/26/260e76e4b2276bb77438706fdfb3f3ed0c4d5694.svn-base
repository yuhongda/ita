<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Resume.aspx.cs" Inherits="Resume" Culture="en-US" UICulture="en-US" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" class="overflow-hidden">
<head>
    <title></title>
    <link rel="icon" type="image/png" href="/images/favicon-32x32.png" sizes="32x32">
    <link rel="icon" type="image/png" href="/images/favicon-16x16.png" sizes="16x16">
    <link rel="icon" type="image/ico" href="/images/favicon.ico">
    <link href="css/resume.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="Scripts/modernizr-2.7.1.min.js"></script>
    <script src="Scripts/rAF-Polyfill.js"></script>
    <script src="Scripts/page-loading.js"></script>
    <script src="Scripts/scroll-to-show.js"></script>
    <script>
        $(function () {
            $.loading({
                selector: '.progress-bar',
                callback: function () {
                    setTimeout(function () {
                        $('.progress-bar-wrap').find('h2').addClass('flip-out');
                        setTimeout(function () {
                            $('.progress-bar-wrap').addClass('progress-bar-wrap-move-back');
                            setTimeout(function () {
                                $('.site-wrapper').addClass('site-wrapper-slide-in');
                                setTimeout(function () {
                                    $('.profile-image-wrap').addClass('flip-in');
                                    setTimeout(function () {
                                        $('header').addClass('move-up');
                                        $('.overflow-hidden').removeClass('overflow-hidden');
                                        setTimeout(function () {
                                            $('.profile-detail').addClass('fade-in');
                                            $('.block-wrap').addClass('fade-in');
                                        }, 2000);
                                    }, 1500);
                                }, 2000);
                            }, 500);
                        }, 1000);

                    }, 2000);
                }
            });

            //z-index for section to fix timeline
            var blocks = $('.block'),
                number = blocks.length;
            $.each(blocks, function (k, v) {
                $(this).css({ 'z-index': number * 10 });
                number--;
            });


            //Skills animation
            function animate(elementId, endPercent) {
                var canvas = document.getElementById(elementId);
                var context = canvas.getContext('2d');
                var x = canvas.width / 2;
                var y = canvas.height / 2;
                var radius = 5;
                var curPerc = 0;
                var counterClockwise = false;
                var circ = Math.PI * 2;
                var quart = Math.PI / 2;

                context.lineWidth = 10;
                context.strokeStyle = '#01439c';
                context.shadowOffsetX = 0;
                context.shadowOffsetY = 0;
                context.shadowBlur = 10;
                context.shadowColor = '#656565';

                function render(current) {
                    context.clearRect(0, 0, canvas.width, canvas.height);
                    context.beginPath();
                    context.arc(x, y, radius, -(quart), ((circ) * current) - quart, false);
                    context.stroke();
                    curPerc++;
                    if (curPerc < endPercent) {
                        requestAnimationFrame(function () {
                            render(curPerc / 100);
                        });
                    }
                }
                render();
            }

            $('ul.skills .list').mouseenter(function () {
                animate($(this).find('canvas').attr('id'), $(this).find('canvas').data('value'));
            });

            $('ul.skills .list').find('canvas').each(function () {
                animate($(this).attr('id'), $(this).data('value'));
            });
        });
       
    </script>
</head>
<body class="overflow-hidden">
<!--[if lt IE 7]>
<p class="chromeframe">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade
    your browser</a> or <a href="http://www.google.com/chromeframe/?redirect=true">activate Google Chrome Frame</a> to
    improve your experience.</p>
<![endif]-->
    <form id="form1" runat="server">
    <div class="progress-bar-wrap">
        <div class="progress-bar"></div>
        <h1><asp:Localize ID="Localize2" Text='<%$ Resources: ResourceGlobal, Resume_Loading  %>' runat="server"></asp:Localize></h1>
        <h2><asp:Localize ID="Localize3" Text='<%$ Resources: ResourceGlobal, Finished  %>' runat="server"></asp:Localize></h2>
    </div>
    
    <div class="site-wrapper">
        <div class="localization">
            <asp:LinkButton ID="lbtnCN" runat="server" onclick="lbtnCN_Click">中文</asp:LinkButton><span>|</span>
            <asp:LinkButton ID="lbtnEN" runat="server" onclick="lbtnEN_Click">En</asp:LinkButton>
        </div>
        <header>
            <div class="profile-image-wrap">
                <div class="profile-image"></div>
                <h1><asp:Localize ID="Localize4" Text='<%$ Resources: ResourceGlobal, YuHongda  %>' runat="server"></asp:Localize></h1>
                <h2><asp:Localize ID="Localize5" Text='<%$ Resources: ResourceGlobal, Description  %>' runat="server"></asp:Localize></h2>
            </div>
        </header>
        <section class="profile-detail">
            <h1><asp:Localize ID="Localize6" Text='<%$ Resources: ResourceGlobal, Profile_1  %>' runat="server"></asp:Localize></h1>
            <h2 class="mt10"><asp:Localize ID="Localize7" Text='<%$ Resources: ResourceGlobal, Profile_2  %>' runat="server"></asp:Localize></h2>
            <h2 class="mt10"><asp:Localize ID="Localize8" Text='<%$ Resources: ResourceGlobal, Profile_3  %>' runat="server"></asp:Localize><br /><asp:Localize ID="Localize9" Text='<%$ Resources: ResourceGlobal, Profile_4  %>' runat="server"></asp:Localize></h2>
            <h3><a href="http://itadesign.cn/resume">itadesign.cn/resume</a></h3>
        </section>

        <div class="block-wrap">
            <section class="block block-black">
                <div class="square"></div>
                <div class="timeline"></div>
                <div class="title"><asp:Localize ID="Localize10" Text='<%$ Resources: ResourceGlobal, My_Story  %>' runat="server"></asp:Localize></div>
                <ul class="">
                    <li class="list list-right swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner"></div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize11" Text='<%$ Resources: ResourceGlobal, Story_Title  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize12" Text='<%$ Resources: ResourceGlobal, Story_Content  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-left swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner"></div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize13" Text='<%$ Resources: ResourceGlobal, Story_Title1  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize14" Text='<%$ Resources: ResourceGlobal, Story_Content1  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-right timeline-point-large swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">2011</div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize15" Text='<%$ Resources: ResourceGlobal, Story_Title2  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize17" Text='<%$ Resources: ResourceGlobal, Story_Content2  %>' runat="server"></asp:Localize></p>
                                <p><asp:Localize ID="Localize16" Text='<%$ Resources: ResourceGlobal, Story_Content22  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-left swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner"></div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize18" Text='<%$ Resources: ResourceGlobal, Story_Title3  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize19" Text='<%$ Resources: ResourceGlobal, Story_Content3  %>' runat="server"></asp:Localize></p>
                                <p><asp:Localize ID="Localize20" Text='<%$ Resources: ResourceGlobal, Story_Content32  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-right timeline-point-large swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">2010</div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize21" Text='<%$ Resources: ResourceGlobal, Story_Title4  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize22" Text='<%$ Resources: ResourceGlobal, Story_Content4  %>' runat="server"></asp:Localize></p>
                                <p><asp:Localize ID="Localize23" Text='<%$ Resources: ResourceGlobal, Story_Content42  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-left swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner"></div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize24" Text='<%$ Resources: ResourceGlobal, Story_Title5  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize25" Text='<%$ Resources: ResourceGlobal, Story_Content5  %>' runat="server"></asp:Localize></p>
                                <p><asp:Localize ID="Localize26" Text='<%$ Resources: ResourceGlobal, Story_Content52  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-right timeline-point-large swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">2007</div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize27" Text='<%$ Resources: ResourceGlobal, Story_Title6 %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize28" Text='<%$ Resources: ResourceGlobal, Story_Content6  %>' runat="server"></asp:Localize></p>
                                <p><asp:Localize ID="Localize29" Text='<%$ Resources: ResourceGlobal, Story_Content62  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-left timeline-point-large swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">2006</div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize30" Text='<%$ Resources: ResourceGlobal, Story_Title7  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize31" Text='<%$ Resources: ResourceGlobal, Story_Content7  %>' runat="server"></asp:Localize></p>
                                <p><asp:Localize ID="Localize32" Text='<%$ Resources: ResourceGlobal, Story_Content72  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                </ul>
            </section>

            <section class="block block-white">
                <div class="square"></div>
                <div class="timeline"></div>
                <div class="title">Skills</div>
                <ul class="skills">
                    <li class="list list-right swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">
                                    <canvas id="canvas1" width="20" height="20" data-value="95"></canvas>
                                </div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize33" Text='<%$ Resources: ResourceGlobal, Skills_Title1  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize34" Text='<%$ Resources: ResourceGlobal, Skills_Content1  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-left swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">
                                    <canvas id="canvas2" width="20" height="20" data-value="95"></canvas>
                                </div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize35" Text='<%$ Resources: ResourceGlobal, Skills_Title2  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize36" Text='<%$ Resources: ResourceGlobal, Skills_Content2  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-right swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">
                                    <canvas id="canvas3" width="20" height="20" data-value="70"></canvas>
                                </div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize37" Text='<%$ Resources: ResourceGlobal, Skills_Title3  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize39" Text='<%$ Resources: ResourceGlobal, Skills_Content3  %>' runat="server"></asp:Localize></p>
                                <p><asp:Localize ID="Localize38" Text='<%$ Resources: ResourceGlobal, Skills_Content32  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-left swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">
                                    <canvas id="canvas4" width="20" height="20" data-value="80"></canvas>
                                </div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize40" Text='<%$ Resources: ResourceGlobal, Skills_Title4  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize41" Text='<%$ Resources: ResourceGlobal, Skills_Content4  %>' runat="server"></asp:Localize></p>
                                <p><asp:Localize ID="Localize42" Text='<%$ Resources: ResourceGlobal, Skills_Content42  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                </ul>
            </section>

            <section class="block block-black">
                <div class="square"></div>
                <div class="timeline"></div>
                <div class="title">Education</div>
                <ul class="skills">
                    <li class="list list-right timeline-point-large swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">2012</div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize50" Text='<%$ Resources: ResourceGlobal, Edu_Title1  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize51" Text='<%$ Resources: ResourceGlobal, Edu_Content1  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-left timeline-point-large swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">2007</div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize52" Text='<%$ Resources: ResourceGlobal, Edu_Title2  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize53" Text='<%$ Resources: ResourceGlobal, Edu_Content2  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-right swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">
                                </div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize54" Text='<%$ Resources: ResourceGlobal, Edu_Title3  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize55" Text='<%$ Resources: ResourceGlobal, Edu_Content3  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                </ul>
            </section>

            <section class="block block-white">
                <div class="square"></div>
                <div class="timeline"></div>
                <div class="title">Contact</div>
                <ul class="">
                    <li class="list list-right timeline-point-middle swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">
                                    <i class="fa fa-user"></i>
                                </div>
                            </div>
                            <div class="block-content">
                                <h2><asp:Localize ID="Localize43" Text='<%$ Resources: ResourceGlobal, Contact_Title1  %>' runat="server"></asp:Localize></h2>
                                <p><asp:Localize ID="Localize44" Text='<%$ Resources: ResourceGlobal, Contact_Content1  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-left timeline-point-middle swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">
                                    <i class="fa fa-envelope"></i>
                                </div>
                            </div>
                            <div class="block-content">
                                <h2><a href="mailto:silverage.y@gmail.com">silverage.y@gmail.com</a></h2>
                                <p><asp:Localize ID="Localize1" Text='<%$ Resources: ResourceGlobal, Contact_Content2  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-right timeline-point-middle swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">
                                    <i class="fa fa-phone"></i>
                                </div>
                            </div>
                            <div class="block-content">
                                <h2>(86) 158-1024-1025</h2>
                                <p><asp:Localize ID="Localize46" Text='<%$ Resources: ResourceGlobal, Contact_Content3  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-left timeline-point-middle swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">
                                    <i class="fa fa-home"></i>
                                </div>
                            </div>
                            <div class="block-content">
                                <h2><a href="http://itadesign.cn/" target="_blank">itadesign.cn</a></h2>
                                <p><asp:Localize ID="Localize45" Text='<%$ Resources: ResourceGlobal, Contact_Content4  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-right timeline-point-middle swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">
                                    <i class="fa fa-twitter-square"></i>
                                </div>
                            </div>
                            <div class="block-content">
                                <h2><a href="https://twitter.com/yuhongda" target="_blank">twitter.com/yuhongda</a></h2>
                                <p><asp:Localize ID="Localize47" Text='<%$ Resources: ResourceGlobal, Contact_Content5  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                    <li class="list list-left timeline-point-middle swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner">
                                    <i class="fa fa-weibo"></i>
                                </div>
                            </div>
                            <div class="block-content">
                                <h2><a href="http://weibo.com/yu619" target="_blank">weibo.com/yu619</a></h2>
                                <p><asp:Localize ID="Localize48" Text='<%$ Resources: ResourceGlobal, Contact_Content6  %>' runat="server"></asp:Localize></p>
                            </div>
                        </div>
                    </li>
                </ul>
            </section>

            <section class="block block-black block-end">
                <div class="square"></div>
                <div class="timeline"></div>
                <div class="title"></div>
                <ul class="skills">
                    <li class="list list-right timeline-point-large swing-out">
                        <div>
                            <div class="timeline-point">
                                <div class="timeline-point-inner"><asp:Localize ID="Localize49" Text='<%$ Resources: ResourceGlobal, END  %>' runat="server"></asp:Localize></div>
                            </div>
                            <div class="block-content">
                            </div>
                        </div>
                    </li>
                </ul>
            </section>
        </div>
    </div>
    </form>
</body>
</html>

