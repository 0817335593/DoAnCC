function echo(st)
{
	document.write(st);
}
function $(id)
{
	if(typeof(id)=='object')
	{
		return id;
	}
	return document.getElementById(id);
}
function toggle(id, status)
{
	if($(id))
	{
		if(typeof(status)!='undefined')
		{
			$(id).style.display = status;
		}
		else if($(id).style.display == 'none')
		{
			$(id).style.display ='';
		}
		else
		{
			$(id).style.display = 'none';
		}
	}
}
function findPos(obj) {
	var curleft = curtop = 0;
	if (obj.offsetParent) {
		do {
			curleft += obj.offsetLeft;
			curtop += obj.offsetTop;
		} while (obj = obj.offsetParent);
	}
	return [curleft,curtop];
}
function select_all_checkbox(form,name,status, select_color, unselect_color)
{
	for (var i = 0; i < form.elements.length; i++) {
		if (form.elements[i].name == 'selected_ids[]') {
			if(status==-1)
			{
				form.elements[i].checked = !form.elements[i].checked;
			}
			else
			{
				form.elements[i].checked = status;
			}
			if(select_color)
			{
				if($(name+'_tr_'+form.elements[i].value))
				{
					$(name+'_tr_'+form.elements[i].value).style.backgroundColor=
						form.elements[i].checked?select_color:unselect_color;
				}
			}
		}
	}
}
function select_checkbox(form, name, checkbox, select_color, unselect_color)
{
	tr_color = checkbox.checked?select_color:unselect_color;
	if(typeof(event)=='undefined' || !event.shiftKey)
	{
		$(name+'_all_checkbox').lastSelected = checkbox;
		if(select_color && $(name+'_tr_'+checkbox.value))
		{
			$(name+'_tr_'+checkbox.value).style.backgroundColor=
				checkbox.checked?select_color:unselect_color;
		}
		update_all_checkbox_status(form, name);
		return;
	}
	//select_all_checkbox(form, name, false, select_color, unselect_color);
	var active = typeof($(name+'_all_checkbox').lastSelected)=='undefined'?true:false;
	for (var i = 0; i < form.elements.length; i++) {
		if (!active && form.elements[i]==$(name+'_all_checkbox').lastSelected)
		{
			active = 1;
		}
		if (!active && form.elements[i]==checkbox)
		{
			active = 2;
		}
		if (active && form.elements[i].id == name+'_checkbox') {
			form.elements[i].checked = checkbox.checked;
			$(name+'_tr_'+form.elements[i].value).style.backgroundColor=
				checkbox.checked?select_color:unselect_color;
		}
		if(active && (form.elements[i]==checkbox && active==1) || (form.elements[i]==$(name+'_all_checkbox').lastSelected && active==2))
		{
			break;
		}
	}
	update_all_checkbox_status(form, name);
}
function update_all_checkbox_status(form, name)
{
	var status = true;
	for (var i = 0; i < form.elements.length; i++) {
		if (form.elements[i].name == 'selected_ids[]' && !form.elements[i].checked) {
			status = false;
			break;
		}
	}
	$(name+'_all_checkbox').checked = status;
}
function make_date_input(input_name, input_value)
{
	echo('<div id="'+input_name+'_div"></div>');
	new Ext.form.DateField({
		name:input_name,
		id:input_name,
		value:input_value,
		renderTo:input_name+'_div',
		format:'d/m/Y'
	});
}
var ns = (navigator.appName.indexOf("Netscape") != -1);
var d = document;
var px = document.layers ? "" : "px";
function JSFX_FloatDiv(id, sx, sy)
{
	var el=d.getElementById?d.getElementById(id):d.all?d.all[id]:d.layers[id];
	window[id + "_obj"] = el;
	if(d.layers)el.style=el;
	el.cx = el.sx = sx;el.cy = el.sy = sy;
	el.sP=function(x,y){this.style.left=x+px;this.style.top=y+px;};
	el.flt=function()
	{
		var pX, pY;
		pX = (this.sx >= 0) ? 0 : ns ? innerWidth :
		document.documentElement && document.documentElement.clientWidth ?
		document.documentElement.clientWidth : document.body.clientWidth;
		pY = ns ? pageYOffset : document.documentElement && document.documentElement.scrollTop ?
		document.documentElement.scrollTop : document.body.scrollTop;
		if(this.sy<0)
		pY += ns ? innerHeight : document.documentElement && document.documentElement.clientHeight ?
		document.documentElement.clientHeight : document.body.clientHeight;
		this.cx += (pX + this.sx - this.cx)/8;this.cy += (pY + this.sy - this.cy)/8;
		this.sP(this.cx, this.cy);
		setTimeout(this.id + "_obj.flt()", 40);
	}
	return el;
}
function numberFormat(nStr)
{
	nStr += '';
	x = nStr.split('.');
	x1 = x[0];
	x2 = x.length > 1 ? '.' + x[1] : '';
	var rgx = /(\d+)(\d{3})/;
	while (rgx.test(x1)) {
		x1 = x1.replace(rgx, '$1' + ',' + '$2');
	}
	return x1 + x2;
}
function isNumeric(sText)
{
	var ValidChars = "0123456789.";
	var isNumeric=true;
	var Char;
	for (i = 0; i < sText.length && isNumeric == true; i++)
	  {
	  Char = sText.charAt(i);
	  if (ValidChars.indexOf(Char) == -1)
		 {
		 isNumeric = false;
		 }
	  }
	return isNumeric;
}
function stringToNumber(string){
	var result = string.replace(',','');
	return parseFloat(result);
}
function start_clock()
{
	var thetime=new Date();
	var nhours=thetime.getHours();
	var nmins=thetime.getMinutes();
	var nsecn=thetime.getSeconds();
	var nday=thetime.getDay();
	var nmonth=thetime.getMonth();
	var ntoday=thetime.getDate();
	var nyear=thetime.getYear();
	var AorP=" ";
	if (nhours>=12)
		AorP="P.M.";
	else
		AorP="A.M.";
	if (nhours>=13)
		nhours-=12;
	if (nhours==0)
	   nhours=12;
	if (nsecn<10)
	 nsecn="0"+nsecn;
	if (nmins<10)
	 nmins="0"+nmins;
	$('clockspot').innerHTML=nhours+": "+nmins+": "+nsecn+" "+AorP;
	setTimeout('start_clock()',1000);
}
/*-----------------------Print-----------------------------------------------*/
function printWebPart(tagid){
    if (tagid && document.getElementById(tagid)) {
		//build html for print page
		if(jQuery("#"+tagid).attr('type')=='land')
		{
			var content = '<div style="page:land;">';
			content += jQuery("#"+tagid).html();
			content += '</div>';
		}else
		{
        	var content = jQuery("#"+tagid).html();
		}
		var html = "<HTML>\n<HEAD>\n"+
            jQuery("head").html()+
            "\n</HEAD>\n<BODY>\n"+
            content+
            "\n</BODY>\n</HTML>";
        //open new window
        html = html.replace(/<TITLE>((.|[\r\n])*?)<\\?\/TITLE>/ig, "");
		html = html.replace(/<script[^>]*>((.|[\r\n])*?)<\\?\/script>/ig, "");
		var printWP = window.open("","printWebPart");
        printWP.document.open();
        //insert content
        printWP.document.write(html);
        printWP.document.close();
        //open print dialog
        printWP.print();
    }
}