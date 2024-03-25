document.addEventListener("DOMContentLoaded", function () {
    showNapThe(); // Hiển thị div khi trang được tải
});

function showNapThe() {
    document.getElementById('napTheContainer').style.display = 'block';
    document.getElementById('topNapTheContainer').style.display = 'none';
    document.getElementById('napButton').classList.add('active');
    document.getElementById('topNapButton').classList.remove('active');
}

function showTopNapThe() {
    document.getElementById('topNapTheContainer').style.display = 'block';
    document.getElementById('napTheContainer').style.display = 'none';
    document.getElementById('topNapButton').classList.add('active');
    document.getElementById('napButton').classList.remove('active');
}
var napTheWidth = document.getElementById('napTheContainer').offsetWidth;
document.getElementById('topNapTheContainer').style.width = napTheWidth + 'px';
