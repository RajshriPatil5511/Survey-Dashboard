const allSideMenu = document.querySelectorAll('#sidebar .side-menu.top li a');

allSideMenu.forEach(item => {
	const li = item.parentElement;

	item.addEventListener('click', function () {
		allSideMenu.forEach(i => {
			i.parentElement.classList.remove('active');
		})
		li.classList.add('active');
	})
}); 


// TOGGLE SIDEBAR
const menuBar = document.querySelector('#content nav  .bx.bx-menu');
const sidebar = document.getElementById('sidebar');

menuBar.addEventListener('click', function () {
	sidebar.classList.toggle('hide');
})

const searchButton = document.querySelector('#content nav form .form-input button');
const searchButtonIcon = document.querySelector('#content nav form .form-input button .bx');
const searchForm = document.querySelector('#content nav form');

/*searchButton.addEventListener('click', function (e) {
	if (window.innerWidth < 576) {
		e.preventDefault();
		searchForm.classList.toggle('show');
		if (searchForm.classList.contains('show')) {
			searchButtonIcon.classList.replace('bx-search', 'bx-x');
		} else {
			searchButtonIcon.classList.replace('bx-x', 'bx-search');
		}
	}
})*/

/*if (window.innerWidth < 768) {
	sidebar.classList.add('hide');
} else if (window.innerWidth > 576) {
	searchButtonIcon.classList.replace('bx-x', 'bx-search');
	searchForm.classList.remove('show');
}*/

/*window.addEventListener('resize', function () {
	if (this.innerWidth > 576) {
		searchButtonIcon.classList.replace('bx-x', 'bx-search');
		searchForm.classList.remove('show');
	}
})*/

const switchMode = document.getElementById('switch-mode');

switchMode.addEventListener('change', function () {
	if (this.checked) {
		document.body.classList.add('dark');
	} else {
		document.body.classList.remove('dark');
	}
})




/* manage survey dropdown js logic */
// scripts.js
/*document.addEventListener("DOMContentLoaded", function () {
	const dropdown = document.getElementById("dropdown");
	const addToTableButton = document.getElementById("addToTable");
	const dataTable = document.getElementById("dataTable").getElementsByTagName('tbody')[0];

	addToTableButton.addEventListener("click", function () {
		const selectedOption = dropdown.value;
		const newRow = dataTable.insertRow();
		const cell = newRow.insertCell(0);
		cell.textContent = selectedOption;
	});
});
*/

// Delete individual row
/*$('table tbody').on('click', '.delete-row', function () {
	$(this).closest('tr').remove();
});
*/




$(function () {
	var PlaceHolderElement = $('#PlaceHolderHere');
	$('button[data-toggle="ajax-modal"]').click(function (event) {
		var url = $(this).data('url');
		var decodedUrl = decodeURIComponent(url);
		$.get(decodedUrl).done(function (data) {
			PlaceHolderElement.html(data);
			PlaceHolderElement.find('.modal').modal('show');
		})
	})
	PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
		var form = $(this).parents('.modal').find('form');
		var actionUrl = form.attr('action');
		var sendData = form.serialize();
		$.post(actionUrl, sendData).done(function (data) {
			PlaceHolderElement.find('.modal').modal('hide');
		})
	})
})


/* loader*/
$(function () {
	$("#loaderbody").addClass('hide');

	$(document).bind('ajaxStart', function () {
		$("#loaderbody").removeClass('hide');
	}).bind('ajaxStop', function () {
		$("#loaderbody").addClass('hide');
	});
});

/*quetions pop up */
/*get model pop up*/
showInPopUp = (url, title) => {
	$.ajax({
		type: "GET",
		url: url,
		success: function (res) {
			$("#form-modal .modal-body").html(res);
			$("#form-modal .modal-title").html(title);
			$("#form-modal").modal('show');
		},
		error: function (xhr, status, error) {
			// Handle errors here, e.g., display an error message.
			console.error("Error loading content:", error);
		}
	});
}


/*Post model pop up */
jQueryAjaxPost = form => {
	try {
		$.ajax({
			type: 'post',
			url: form.action,
			data: new FormData(form),
			contentType: false,
			processData: false, // Add this to prevent jQuery from processing data
			success: function (res) {
				if (res.isvalid) {
					$("#view-all").html(res.html);
					$("#form-modal .modal-body").html('');
					$("#form-modal .modal-title").html('');
					$("#form-modal").modal('hide'); // Corrected modal hide method
					$.notify('submitted successfully', { globalPosition: 'top center', className:'success' });
				}
				else
					$("#form-modal .modal-body").html(res.html);
			},
			error: function (err) {
				console.log(err);
			}
		});
	}
	catch (e) {
		console.log(e);
	}
	return false;
}

jQueryAjaxDelete = form => {

	if (confirm('are you sure to delete ?')) {
		try {
			$.ajax({
				
					type: 'post',
					url: form.action,// Add this to prevent jQuery from processing data
					data: new FormData(form),
					contentType: false,
					processData: false, 
				success: function (res) {

					$("#view-all").html(res.html);
					$.notify('Deleted successfully', { globalPosition: 'top center', className:'success' });

				},
					error: function (err) {
						console.log(err);
					}
				})
		} catch (e) {
			console.log(e);
		}
	}
	return false;
}


/* counter effect  */
const counters = document.querySelectorAll(".count");
const speed = 200;
const delay = 30; // Increase this value for a slower counting speed

counters.forEach((counter) => {
	const updateCount = () => {
		const target = parseInt(+counter.getAttribute("data-target"));
		const count = parseInt(+counter.innerText);
		const increment = Math.trunc(target / speed);
		console.log(increment);

		if (count < target) {
			counter.innerText = count + increment;
			setTimeout(updateCount, delay); // Increase the delay here
		} else {
			counter.innerText = target;
		}
	};
	updateCount();
});
/* render surveyform partial view */
/*$(function () {
	$("#surveyDropdown").change(function () {
		var SurveyId = $("#surveyDropdown").val();
		// var selectedQuestionIds = $("#questionDropdown").val();

		if (SurveyId) {
			$.ajax({
				url: '@Url.Action("Details", "SurveyManagerController")',
				data: { SurveyId: SurveyId },
				method: 'GET',
				success: function (partialView) {
					$("#surveyDetails").html(partialView);
				}
			});
		} else {
			$("#Index").empty();
		}


	});
});*/

/*$(document).ready(function () {
	$("#deleteButton").click(function () {
		if (confirm('Are you sure you want to delete this item?')) {
			var manageID = $(this).data("manageid");
			$.ajax({
				type: 'post',
				url: '/SurveyManager/Index/FilteredIndex/DeleteConfirmed', // Replace with the actual URL
				data: { ManageID: manageID },
				success: function (response) {
					$("#view-all").html(response.html);
					// Handle success, e.g., show a notification
				},
				error: function (err) {
					console.log(err);
					// Handle error, e.g., show an error message
				}
			});
		}
	});
});*/