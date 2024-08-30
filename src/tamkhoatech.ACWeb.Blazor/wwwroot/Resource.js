
let DotNetObjectReference; // biến chứa địa chỉ hiện tại của page
function getDotNetObjectReference(dotNetObjectReference) { //Hàm lấy địa chỉ hiện tại
    DotNetObjectReference = dotNetObjectReference;
}
//Chức năng Export Excel
window.downloadFileFromBase64 = (fileName, contentType, base64) => {
    const linkSource = `data:${contentType};base64,${base64}`;
    const downloadLink = document.createElement("a");//tạo thẻ <a> liên kết với DOM
    downloadLink.href = linkSource;
    downloadLink.download = fileName;
    downloadLink.click();
};
//Chức năng Export Excel end

//Rename text
    //Rename page size
    function renamePageSize(text) {
        let elements = document.getElementsByClassName('e-constant');
        for (const element of elements) {
            element.innerText = text;
        }
    }
    //Rename input search in show column
    function renameShowColumn(text) {
        let element = document.querySelector('.e-grid .e-ccdlg .e-cc.e-input');
        if (element) {
            element.placeholder = text; // Thay đổi nội dung placeholder
        }
    }
//Rename text end

//Thay đổi độ rộng footer trong màn hình nhập liệu khi bật tắt sidebar
function changeWidthContentBySidebar() {
    let sidebar = document.getElementById('sidebar');
    if (!sidebar) return;

    let navbar = document.getElementById('main-navbar');
    let footer = document.querySelector('.fixed-footer');

    if (sidebar.classList.contains('e-close')) {
        if (navbar) {
            navbar.style.width = '100%';
            navbar.style.transition = 'none';
        }
        if (footer) {
            footer.style.width = '100%';
            footer.style.transition = 'bottom 1s ease';
        }
    } else if (sidebar.classList.contains('e-open')) {
        if (navbar) {
            navbar.style.width = '';
            navbar.style.transition = '';
        }
        if (footer) {
            footer.style.width = '';
            footer.style.transition = '';
        }
    }
}

//Thay đổi độ rộng footer trong màn hình nhập liệu khi bật tắt sidebar end


// Xử lý sự kiện scroll
let lastScrollTop = 0;
window.addEventListener('scroll', function () {
    // Lấy phần tử footer
    let footer = document.getElementById('nhap-lieu-footer');
    if(footer) {
        let scrollTop = window.scrollY || document.documentElement.scrollTop;

        if (scrollTop > lastScrollTop) {
            footer.style.bottom = '-100px';
        } else {
            footer.style.bottom = '0';
        }

        // Lưu vị trí scroll hiện tại để so sánh với vị trí scroll trước đó
        lastScrollTop = scrollTop;
    }

}, false);
// Xử lý sự kiện scroll end

//Hàm tìm kiếm khi nhấn phiếm Enter trên navbarMenu
async function searchInputNavbar(event)
{
    if (event.key === 'Enter' && DotNetObjectReference != undefined) {
        let searchElement = document.getElementById('navbar-search');
        if (document.activeElement === searchElement)//kiểm tra thẻ input có đang focus
            await DotNetObjectReference.invokeMethodAsync('searchInputNavbar', searchElement.value.trim());//Gọi hàm SearchAsync trong razor page
    }
}
//Hàm tìm kiếm khi nhấn phiếm Enter trên navbarMenu end

//Code thực hiện chức năng di chuyển khi nhấn phím mũi tên

async function navigateInputsAsync(event, inputCommonIds, inputDetailIds) {
    // Lấy phần tử hiện tại đang có tiêu điểm (focus)
    let currentInput = document.activeElement;
    let currentID = currentInput.id;
    // Tìm vị trí hiện tại
    let currentIndexCommon = inputCommonIds.indexOf(currentID);
    let currentIndexDetail = inputDetailIds.indexOf(currentID);
    if (currentIndexCommon >= 0) { // Kiểm tra xem phần tử hiện tại có trong mảng không
        if (event.key === "ArrowRight") {
            await navigateNextInputsCommonAsync(currentIndexCommon, inputCommonIds, inputDetailIds[0]);
        } else if (event.key === "ArrowLeft"){
            navigatePrevInputsAsync(currentIndexCommon, inputCommonIds);
        }
    }
    else if (currentIndexDetail >= 0) {
        if (event.key === "ArrowRight") {
            await navigateNextInputsDetailAsync(currentIndexDetail, inputDetailIds);
        }
        else if (event.key === "ArrowLeft") {
            navigatePrevInputsAsync(currentIndexDetail, inputDetailIds);
        }
    }
    else {
        await focusInputAsync(inputCommonIds, inputDetailIds);

    }
}

//Hàm điều hướng thông tin chung
async function navigateNextInputsCommonAsync(currentIndex, inputIds, firtInputIdDetail)
{
    // Chuyển đến input tiếp theo trong mảng
    let nextIndex = (currentIndex + 1) % inputIds.length;
    let nextInput = document.getElementById(inputIds[nextIndex]);
    let index = checkInputIdIsDisable(nextInput, nextIndex, inputIds);
    let focusInput = document.getElementById(inputIds[index]);
    if ((index === inputIds.length - 1 && focusInput.disabled) || index === 0) {
        let isEdit = await DotNetObjectReference.invokeMethodAsync('IsEditSfGridCt');
        if (!isEdit){
            await DotNetObjectReference.invokeMethodAsync('SfGridCtAddRecordAsync');
        }
        let focusInputDetail = document.getElementById(firtInputIdDetail);
        if (focusInputDetail)
            focusInputDetail.focus();
    }
    else {
        focusInput.focus();
    }
}
//Hàm điều hướng thông tin chi tiết
async function navigateNextInputsDetailAsync(currentIndex, inputIds) {
    // Chuyển đến input tiếp theo trong mảng
    let nextIndex = (currentIndex + 1) % inputIds.length;
    let nextInput = document.getElementById(inputIds[nextIndex]);
    let index = checkInputIdIsDisable(nextInput, nextIndex, inputIds);
    let focusInput = document.getElementById(inputIds[index]);
    if ((index === inputIds.length - 1 && focusInput.disabled) || index === 0) {
        await DotNetObjectReference.invokeMethodAsync('SfGridCtEndEditAsync');
        let isEdit = await DotNetObjectReference.invokeMethodAsync('IsEditSfGridCt');
        if (isEdit) {
            let focusInputDetail = document.getElementById(inputIds[0]);
            if (focusInputDetail)
                focusInputDetail.focus();
        }
        else {
            await DotNetObjectReference.invokeMethodAsync('SfGridCtAddRecordAsync');
        }
    }
    else {
        focusInput.focus();
    }
}
function navigatePrevInputsAsync(currentIndex, inputIds) {
    // Chuyển đến input tiếp theo trong mảng
    let prevIndex = (currentIndex - 1 + inputIds.length) % inputIds.length;
    let prevInput = document.getElementById(inputIds[prevIndex]);
    while (prevInput === null || prevInput.disabled) {
        // Chuyển đến input trước đó
        prevIndex = (prevIndex - 1 + inputIds.length) % inputIds.length;
        prevInput = document.getElementById(inputIds[prevIndex]);
        // Nếu quay lại input ban đầu, dừng lại (tránh vòng lặp vô tận)
        if (prevIndex === currentIndex) {
            break; // Không có input nào khả dụng
        }
    }
    if (prevInput) {
        prevInput.focus();
    }
}
//hàm bỏ qua inputs bị disable
function checkInputIdIsDisable(input, index, inputIds) {
    while (input === null || input.disabled) {
        if (index === inputIds.length -1) {
            break;
        }
        // Chuyển đến input tiếp theo
        index = (index + 1) % inputIds.length;
        input = document.getElementById(inputIds[index]);
    }
    return index;
}
//Hàm focus input khi bị blur
async function focusInputAsync(inputCommonIds, inputDetailIds) {
    const isEdit = await DotNetObjectReference.invokeMethodAsync('IsEditSfGridCt');
    const inputIds = isEdit ? inputDetailIds : inputCommonIds;
    const index = checkInputIdIsDisable(document.getElementById(inputIds[0]), 0, inputIds);
    const focusInput = document.getElementById(inputIds[index]);
    if (focusInput) focusInput.focus();
}
//Code thực hiện chức năng di chuyển khi nhấn phím mũi tên end

//Hàm tắt thông báo mặc định khi xóa của grid
function turnOffMessageDefaultGrid(gridCtId){
    let innerDiv = document.querySelector(`#${gridCtId} .e-dlg-container.e-dlg-modal.e-dlg-center-center`);
    if (innerDiv) {
        innerDiv.classList.add('display-none');
    }
}
