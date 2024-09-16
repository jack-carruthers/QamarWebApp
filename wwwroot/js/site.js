// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function() {
    var dropdown = document.querySelector('.dropdown');
    var dropdownButton = document.querySelector('.dropdown-button');
    var dropdownContent = document.querySelector('.dropdown-content');

    dropdownButton.addEventListener('click', function() {
        // Toggle the display of the dropdown content
        if (dropdownContent.style.display === 'block') 
            {
            dropdownContent.style.display = 'none';
        } 
        
        else {
            dropdownContent.style.display = 'block';
        }
    });

    // Close the dropdown if the user clicks outside of it
    window.addEventListener('click', function(event) {
        if (!dropdown.contains(event.target)) {
            dropdownContent.style.display = 'none';
        }
    });
});

