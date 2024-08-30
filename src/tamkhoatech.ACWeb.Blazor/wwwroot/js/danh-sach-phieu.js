document.addEventListener("keydown", async function (event) {
    if (event.key === 'Enter') {
        event.preventDefault();
        await searchInputNavbar(event);
    }
});