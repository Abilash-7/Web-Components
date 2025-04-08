<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadingPage.aspx.cs" Inherits="Learning.LoadingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        .main{
            height:100VH;
        }
   #loader-overlay {
    position: fixed;
    top: 0; left: 0;
    width: 100vw;
    height: 100vh;
    background-color: rgba(0, 0, 0, 0.6); /* semi-transparent black */
    backdrop-filter: blur(10px); /* blur effect */
    display: flex;
    align-items: center;
    justify-content: center;
    z-index: 9999;
    font-size: 24px;
    font-family: Arial;
}


   .loader, .loader:before, .loader:after {
  border-radius: 50%;
  width: 2.5em;
  height: 2.5em;
  animation-fill-mode: both;
  animation: bblFadInOut 1.8s infinite ease-in-out;
}
.loader {
  color: #fff;
  font-size: 7px;
  position: relative;
  text-indent: -9999em;
  transform: translateZ(0);
  animation-delay: -0.16s;
}
.loader:before,
.loader:after {
  content: '';
  position: absolute;
  top: 0;
}
.loader:before {
  left: -3.5em;
  animation-delay: -0.32s;
}
.loader:after {
  left: 3.5em;
}

@keyframes bblFadInOut {
  0%, 80%, 100% { box-shadow: 0 2.5em 0 -1.3em }
  40% { box-shadow: 0 2.5em 0 0 }
}
    
} 
</style>



  <script>
      // Delay before showing loader (in ms)
      const showDelay = 300;

      // Only show loader if page takes longer than showDelay
      const showLoader = setTimeout(() => {
          document.getElementById("loader-overlay").style.display = "flex";
      }, showDelay);

      // Once page fully loads, cancel the loader
      window.addEventListener("load", function () {
          clearTimeout(showLoader);
          document.getElementById("loader-overlay").style.display = "none";
      });
  </script>




</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div id="loader-overlay" style="display: none;">
              <span class="loader"></span>
            </div>

        </div>
    </form>
</body>
</html>
