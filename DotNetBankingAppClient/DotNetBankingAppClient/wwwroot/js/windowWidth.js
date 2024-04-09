// Manages the registered event listeners so they can be disposed later
let windowEventListeners = {};

window.getWidth = function () {
    return window.innerWidth;
};

function AddWindowWidthListener(objReference) {
    let eventListener = () => UpdateWindowWidth(objReference);
    window.addEventListener("resize", eventListener);
    windowEventListeners[objReference] = eventListener;
}

function RemoveWindowWidthListener(objReference) {
    window.removeEventListener("resize", windowEventListeners[objReference]);
}

function UpdateWindowWidth(objReference) {
    objReference.invokeMethodAsync("OnWindowWidthChange", window.innerWidth);
}

function GetWidth(objReference) {
    objReference.invokeMethodAsync("OnWindowWidthChange", window.innerWidth);
}