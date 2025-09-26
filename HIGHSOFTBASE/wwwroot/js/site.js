// site.js
document.addEventListener('DOMContentLoaded', function () {
    const toggle = document.querySelector('.sidebar-toggle');
    const sidebar = document.querySelector('.app-sidebar');

    if (toggle && sidebar) {
        toggle.addEventListener('click', () => {
            sidebar.classList.toggle('show');
        });

        // close when clicking outside
        document.addEventListener('click', (e) => {
            if (window.innerWidth < 992 && sidebar.classList.contains('show')) {
                const isClickInside = sidebar.contains(e.target) || (toggle && toggle.contains(e.target));
                if (!isClickInside) {
                    sidebar.classList.remove('show');
                }
            }
        });
    }
});
