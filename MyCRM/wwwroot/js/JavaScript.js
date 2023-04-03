SidebarTrue = true;
SideWarpTrue = true;

document.querySelector("#SidebarIsOpent").onclick = ffff;
function ffff() {
    if (SidebarTrue) {
        document.querySelector("#sbar").classList.remove('open');
        document.querySelector("#main").style.paddingLeft  = '0px';
        SidebarTrue = false;
    }
    else {
        document.querySelector("#sbar").classList.add('open');
        document.querySelector("#main").style.paddingLeft  = '250px';
        SidebarTrue = true;
    }
}

document.querySelector("#USERNAME").onclick = fff;
function fff() {
    if (SideWarpTrue) {
        SideWarpTrue = false;
        document.querySelector(".sideAccount").classList.add('AccountOpen');
    }
    else {
        SideWarpTrue = true;
        document.querySelector(".sideAccount").classList.remove('AccountOpen');
    }
}