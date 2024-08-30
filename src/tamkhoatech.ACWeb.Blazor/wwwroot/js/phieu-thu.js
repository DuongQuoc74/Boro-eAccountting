let InputCommonIds;
let InputDetailIds;
let GridCtId;
export function getInputIds(inputsCommon, inputsDetail, gridCtId) {
    InputCommonIds = inputsCommon;
    InputDetailIds = inputsDetail;
    GridCtId = gridCtId;
}
document.addEventListener("keydown", async function (event) {
    if (event.key === 'F1' || event.key === 'F2' || event.key === 'F3' || event.key === 'F5'
        || event.key === 'F7' || event.key === 'F9'
        || event.key === 'F11' || event.key === 'F12' || event.key === 'Tab') {
        event.preventDefault();
    }
    else if (event.key === 'F4') {
        event.preventDefault();
        await DotNetObjectReference.invokeMethodAsync('SfGridCtAddRecordAsync');
        await focusInputAsync(InputCommonIds, InputDetailIds);
    }
    else if (event.key === 'F6') {
        event.preventDefault();
        await DotNetObjectReference.invokeMethodAsync('SfGridCtSelectRowAsync');
    }
    else if (event.key === 'F8') {
        event.preventDefault();
        await DotNetObjectReference.invokeMethodAsync('SfGridCtDeleteRecordAsync');
        turnOffMessageDefault(10);
    }
    else if (event.key === 'F10') {
        event.preventDefault();
        await DotNetObjectReference.invokeMethodAsync('SfGridCtCancelRecordAsync');
    }
    else if (event.key === "ArrowRight" || event.key === "ArrowLeft") {
        event.preventDefault();
        await navigateInputsAsync(event, InputCommonIds, InputDetailIds);
    }
   
});
export function turnOffMessageDefault(timeout = 50) {
    setTimeout(() => {
        turnOffMessageDefaultGrid(GridCtId); // Tắt thống báo mặc định
    }, timeout);
}

