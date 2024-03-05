export default function toastMessage(message, type) {
    let background = type == "error"
        ? "linear-gradient(to right, #fd1d1d, #fc458f)"
        : "linear-gradient(to right, #00b09b, #96c93d)";

    Toastify({
        text: message,
        duration: 5000,
        destination: "https://github.com/apvarun/toastify-js",
        newWindow: true,
        close: true,
        gravity: "bottom",
        position: "right",
        stopOnFocus: true,
        style: {
            background: background,
        },
        onClick: function () { }
    }).showToast();
}