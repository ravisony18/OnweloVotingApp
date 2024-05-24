$(function () {
	var PlaceHolderElement = $('#PlaceHolderHere');
	// Model Popups -Client Connect Report To Open Partial Views
	$('#ClientConnectReport tbody').on('click', 'button', function () {
		var url = $(this).data('url');
		var decodeUrl = decodeURIComponent(url);
		$.get(decodeUrl).done(function (data) {
			PlaceHolderElement.html(data);
			PlaceHolderElement.find('.modal').modal('show');
		})
	})
})