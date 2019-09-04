function getTodayDate() {
	var m_names = new Array("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec");
	var d = new Date();
	var curr_date = d.getDate();
	var curr_month = d.getMonth();
	var curr_year = d.getFullYear();
	
	var today = m_names[curr_month] + " " + curr_date + ", " + curr_year;
	return today;
}


function showMessage(msg, error) {
	
	if (error == false) {
		var toastHTML = '<span>' + msg+' </span>';
		M.toast({ html: toastHTML });
	}
	else {
		var toastHTML = '<span style="color:red;">'+msg+'</span>';
		M.toast({ html: toastHTML });
	}

}