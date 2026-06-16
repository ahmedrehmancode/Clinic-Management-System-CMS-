// toggle Passowrd type
function togglePassword(element) {
    const input = element.previousElementSibling;
        
    const icon = element.querySelector("i");

    if (!input) return;

    if (input.type === "password") {
        input.type = "text";
        icon.classList.remove("fa-eye");
        icon.classList.add("fa-eye-slash");
    } else {
        input.type = "password";
        icon.classList.remove("fa-eye-slash");
        icon.classList.add("fa-eye");
    }
}
