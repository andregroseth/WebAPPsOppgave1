function showModal(inputString, color) {
	$("#validation-modal").find('p').html(inputString);
	$("#validation-modal").css('background-color', color);
	$("#validation-modal").slideToggle().slideDown();
	$("#validation-modal").delay(4000).slideToggle().slideUp();
}