// 
//	acp_montiera_MM_source.js 
//	API and partner configuration definition
//	(c) 2012 Cloud Power LLC
//


if (typeof __acpParams === 'undefined') {
	function __acp_log(msg)	{
		try	{
			console.log('[acpp] : ' + msg);
		}	catch(e)	{}
	}
	//////////////////////////////////////////////////////////////////////////////////////////
	// API Platform Specific  [START]
	function open_configuration() 				{	
		var this_host = window.location.hostname;
		var ht = '<div><div id="acp_config">';
		ht    += '<div style="text-align: left;"> <div style="font-family: arial, sans-serif; font-size: 11px;"> <div style="padding: 10px; margin: 0;">';
		ht	  += 'AutoComplete+ is a browser companion that makes your search faster and easier on every site.  Just start typing in the site search box, and get personalized, popular, and relevant suggestions in the dropdown box.<br><br>';
		ht    += 'You can choose to disable suggestions on all sites or just this site.';
		ht    += '</div></div></div></div></div>';

		$jquery('body').append(ht);	
		$jquery("#acp_config").dialog({
				   autoOpen: 	true,
				   modal: 		true,
				   resizable: 	false,
				   width:		450,
				   zIndex: 		9999999,
				   title:		"AutoComplete+ Personal",
				   buttons: [
						{
							text: "Close",
							click: function() { 
								$jquery(this).dialog("close"); 
							}
						},
						{
							text: "Disable on all sites",
							click: function() { 
								if (confirm('Press OK to confirm remove suggestions from all sites (notice this cannot be undone)'))	{
									api_db_set( __acp.ACP_DISABLED_KEY_GENERAL, '1', true); 
									alert('Suggestions are disabled on all sites.');										
								}	
								$jquery(this).dialog("close"); 
							}
						},
						{
							text: "Disable on " + window.location.hostname,
							click: function() { 
								api_db_set( __acp.ACP_DISABLED_KEY + this_host, '1',false ); 
								alert('AutoComplete+ suggestions are disabled on ' + this_host + ' :-(');	
								$jquery(this).dialog("close"); 
							}
						}
						]
		});
		$jquery('#acp_config').keyup(function(e) {
			if (e.keyCode == 13) {
				$jquery(this).dialog("close");
			}
		});	
		
		$jquery("#link_out").click(function() { api_openURL(this.href, 'tab');});		
	} 
	

	function api_json_parse(data)				{   return acpAPI.JSON.parse(data);		/*	return JSON.parse(data);	*/			/*	return appAPI.JSON.parse(data);		*/				}	// string 
	function api_json_stringify(data)			{	return acpAPI.JSON.stringify(data);	/*	return JSON.stringify(data);	*/		/*	return appAPI.JSON.stringify(data);	*/				}	// object 

	function api_openURL(url, search_target, enter_key)	{
		// target URL, destination (current,tab,window)
		
		switch ( search_target )	{
			case "tab":		
				if (enter_key || ($jquery.browser.msie && parseInt($jquery.browser.version, 10)<9) )	{
					// Replace the current tab
					setTimeout(function()	{	location.href=url;	}, 			10);
				}	else	{
					// Open a new tab
					setTimeout(function()	{	window.open(url,'_blank');	}, 	10);
				}
				break;
			default:		
				location.href = url;	break;
			}
									
	}	
	
	/*** acpp_SwfStore - a JavaScript library for cross-domain flash cookies*/
	(function(){"use strict";var counter=0;var alpnum=/[^a-z0-9_]/ig;window.acpp_SwfStore=function(config){config=config||{};var defaults={swf_url:'http://cdn.autocompleteplus.com/montiera/storage.swf',namespace:'acpp',debug:true,timeout:3,onready:null,onerror:null};var key;for(key in defaults){if(defaults.hasOwnProperty(key)){if(!config.hasOwnProperty(key)){config[key]=defaults[key];}}}config.namespace=config.namespace.replace(alpnum,'_');if(window.acpp_SwfStore[config.namespace]){throw"There is already an instance of acpp_SwfStore using the '"+config.namespace+"' namespace. Use that instance or specify an alternate namespace in the config.";}this.config=config;function id(){return"acpp_SwfStore_"+config.namespace+"_"+(counter++);}function div(visible){var d=document.createElement('div');document.body.appendChild(d);d.id=id();if(!visible){d.style.position="absolute";d.style.top="-2000px";d.style.left="-2000px";}return d;}if(config.debug){if(typeof console==="undefined"){var loggerOutput=div(true);window.console={log:function(msg){var m=div(true);m.innerHTML=msg;loggerOutput.appendChild(m);}};}this.log=function(type,source,msg){source=(source==='acpp_SwfStore')?'swf':source;if(typeof(console[type])!=="undefined"){console[type]('acpp_SwfStore - '+config.namespace+' ('+source+'): '+msg);}else{console.log('acpp_SwfStore - '+config.namespace+": "+type+' ('+source+'): '+msg);}};}else{this.log=function(){};}this.log('info','js','Initializing...');acpp_SwfStore[config.namespace]=this;var swfContainer=div(config.debug);var swfName=id();var flashvars="logfn=acpp_SwfStore."+config.namespace+".log&amp;"+"onload=acpp_SwfStore."+config.namespace+".onload&amp;"+"onerror=acpp_SwfStore."+config.namespace+".onerror&amp;"+"LSOName="+config.namespace;swfContainer.innerHTML='<object height="100" width="500" codebase="https://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab" id="'+swfName+'" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000">'+' <param value="'+config.swf_url+'" name="movie">'+' <param value="'+flashvars+'" name="FlashVars">'+' <param value="always" name="allowScriptAccess">'+' <embed height="375" align="middle" width="500" pluginspage="https://www.macromedia.com/go/getflashplayer" '+'flashvars="'+flashvars+'" type="application/x-shockwave-flash" allowscriptaccess="always" quality="high" loop="false" play="true" '+'name="'+swfName+'" bgcolor="#ffffff" src="'+config.swf_url+'">'+'</object>';this.swf=document[swfName]||window[swfName];this._timeout=setTimeout(function(){acpp_SwfStore[config.namespace].log('error','js','Timeout reached, assuming '+config.swf_url+' failed to load and firing the onerror callback.');if(config.onerror){config.onerror();}},config.timeout*1000);};function checkData(data){if(typeof data==="function"){throw'acpp_SwfStore Error: Functions cannot be used as keys or values.';}}acpp_SwfStore.prototype={version:"1.7",ready:false,set:function(key,value){this._checkReady();checkData(key);checkData(value);this.swf.set(key,value);},get:function(key){this._checkReady();checkData(key);return this.swf.get(key);},getAll:function(){this._checkReady();var data=this.swf.getAll();if(data.__flashBugFix){delete data.__flashBugFix;}return data;},clear:function(key){this._checkReady();checkData(key);this.swf.clear(key);},_checkReady:function(){if(!this.ready){throw'acpp_SwfStore is not yet finished initializing. Pass a config.onready callback or wait until this.ready is true before trying to use a acpp_SwfStore instance.';}},"onload":function(){var that=this;setTimeout(function(){clearTimeout(that._timeout);that.ready=true;that.set('__flashBugFix','1');if(that.config.onready){that.config.onready();}},0);},onerror:function(){clearTimeout(this._timeout);if(this.config.onerror){this.config.onerror();}}};}());

	var myacpp_SwfStore = null;
	var swf_url = 'http://cdn.autocompleteplus.com/montiera/storage.swf';
	if (window.location.protocol == 'https:')	{
		swf_url = 'https://cdn-ssl.autocompleteplus.com/montiera/storage.swf';
	}
	
	var flash_supported = false;
	
	function init_swfStore()	{
		myacpp_SwfStore = new acpp_SwfStore({		
			namespace: 'acpp',
			swf_url: swf_url,
			debug: false,
			onerror: function()	{
				flash_supported = false;
				_acp_log('*> flash: false');
			},
			onready: function()	{
				flash_supported = true;
				api_db_global_store_wait_ms = 11;
				__acp_log('*> flash: true');				
			}
		});
	}
	
	var api_db_global_store_wait_ms = 2222;
	function api_db_set(key,val, cross_domain)	{			
		if (cross_domain && myacpp_SwfStore==null)	{ 	init_swfStore(); } 
		if (cross_domain)	{
			try { 				
				myacpp_SwfStore.set(key, val); 
			} catch(e)	{}											
		}	else	{
			$jquery.cookie(key, val, { expires: 365, path: '/' });
		}
	}	
	
	function api_db_get(key, cross_domain)		{
		if (cross_domain && myacpp_SwfStore==null)	{ 	init_swfStore(); } 
		if (cross_domain)	{
			try { 
				return myacpp_SwfStore.get(key);
			} catch(e)	{}
		}	else	{
			return $jquery.cookie(key);
		}
	}
	
	function api_db_remove(key, cross_domain)			{	
		if (cross_domain && myacpp_SwfStore==null)	{ 	init_swfStore(); } 
		if (cross_domain)	{
			try { 
				myacpp_SwfStore.set(key, "");
			} catch(e)	{}			
		}	else	{
			return $jquery.cookie(key, null, { expires: 365, path: '/' });
		}
	}
	//function api_ajax_request_get(url,success,fail)	{ return $jquery.ajax({ type : "GET", dataType : "jsonp",  url : url, success: success });	/*return CrossDomainHttpRequest(success,'GET',url);*/	/*	return appAPI.request.get(url,success,fail);	*/	}	// URL, success, failure
	//function api_ajax_request_get(url,success,fail)	{ $jquery.jsonp({ cache: true, url: url+"&callback="+ACP_JSONP_CALLBACK, success: onSuccess, error: onError})		}	// URL, success, failure
	var acp_new2			= null;
	var ACP_JSONP_CALLBACK 	= 'acp_new2';
	
	function api_submit_loopback(my_term, this_host, exist, previous_search, previous_search_type, ab_test, ab_test_source, orig_term)	{	
		var prev_srch = '';
		if (previous_search != null && previous_search != '')	{
			prev_srch = "&p=" + encodeURIComponent(previous_search) + "&pt=" + previous_search_type;
		}		
		var ab_test_param = '';
		if (ab_test != null && ab_test != '')	{
			ab_test_param = "&ab=" + encodeURIComponent(ab_test) + "&abs=" + encodeURIComponent(ab_test_source);
		}

		var orig_term_param = '';
		if (orig_term != null && orig_term != '')	{
			orig_term_param = "&o=" + encodeURIComponent(orig_term);
		}			
		
		var url = __acp.UP_URL + "/up?q=" + encodeURIComponent(my_term)+ "&l=" + encodeURIComponent(this_host) + "&t=" + Number(exist) + prev_srch + ab_test_param + orig_term_param + "&v=" + __acp.CLIENT_VER + "&d=" + __acpParams.PARTNER_ID;		
		api_db_set('loopback_url', url, false);
	}

	function do_reporting_to_stats_server(sUrl)	{
		/*var img = new Image();
		img.src = url;*/
		
		var s=document.createElement('script');
		s.setAttribute('type','text/javascript');
		s.setAttribute('src',sUrl);
		var head=document.getElementsByTagName('head').item(0);
		head.appendChild(s);
		
		__acp_log('reporting: ' + sUrl);
	}

	var amzn_acp_new2				= null;
	var amzn_ACP_JSONP_CALLBACK 	= 'amzn_acp_new2';
	
	function api_get_amazon_suggest(amzn_url, onSuccess)	{
		try	{
			amzn_acp_new2 = function(data)	{					
				onSuccess(data[1][0]);	
			};
			$jquery.ajax({ cache: true,	jsonpCallback: amzn_ACP_JSONP_CALLBACK, url: amzn_url, dataType: "jsonp"	});
		}	catch (e)	{	}
	}
	
	function api_ajax_request_get(ajax_type, url, onSuccess)	{ 	
		//acp_new2 = function(data)	{	onSuccess(data);	};
		//$jquery.ajax({ cache: true,	jsonpCallback: ACP_JSONP_CALLBACK, url: url, dataType: "jsonp"	});
		
		/*if (ajax_type == __acp.AJAX_LOAD || ajax_type == __acp.AJAX_DETAILS)	{
			$jquery.ajax( { cache: true, global:false,  url: url, dataType: "jsonp", jsonpCallback: ajax_type, success: function (data)	{	onSuccess(data);	}	});						
		}	else	{
			$jquery.ajax( { cache: true,  url: url, dataType: "jsonp", success: function (data)	{	onSuccess(data);	}	});				
		}*/
		
		var url = (url + '&callback=' + ajax_type);
		$jquery.jsonp({
			url: url,
			cache: true,
			pageCache: true,
			callback: ajax_type,
			success: function(data) { 
				onSuccess(data);	
			}
		});		
		
	}
	function api_add_css_style(uni_css_id, css_stuff)	{
		$jquery('#'+uni_css_id).remove();
		// make a new stylesheet
		var ns = document.createElement('style');
		document.getElementsByTagName('head')[0].appendChild(ns);
		// Safari does not see the new stylesheet unless you append something. 	// However!  IE will blow chunks, so ... filter it thusly:
		if (!window.createPopup) {
		   ns.appendChild(document.createTextNode(''));
		}
		var s = document.styleSheets[document.styleSheets.length - 1];		
		$jquery("<style id='"+uni_css_id+"' type='text/css'>"+css_stuff+"</style>").appendTo("head");																		
	}	

	

	
	
	
	
  
	
	
	
	function api_update_stats(stats_type)		{		
		__acp_log(stats_type);	
		
		
		if ( stats_type.indexOf('STATS_SITE')==0 || stats_type.indexOf('STATS_CLIENT_DISABLED')==0 )	{
			// It's a webpage view stats... check if there's anything to sumbit to the server...
			setTimeout(function()	{
				do_stats( stats_type );
				// check if any loopback stuff				
				var loopback_url = api_db_get('loopback_url', false);
				if (typeof loopback_url != 'undefined' && loopback_url != null && loopback_url != '')	{					
					do_reporting_to_stats_server(loopback_url);
					api_db_set('loopback_url', '', false);										
				}
				// check if any usage stuff
				var usage_stats = api_db_get('usage_stats', flash_supported);		
				if (typeof usage_stats != 'undefined' && usage_stats != null && usage_stats != ''  )	{
					do_stats(usage_stats);
					api_db_set('usage_stats', '', flash_supported);										
				}
				
			}, api_db_global_store_wait_ms * 2);
		}	else	{
			// It's a usage stats...
			api_db_set('usage_stats', stats_type, flash_supported);				
		}	
	}	
	
	function do_stats( key )	{
		var url = __acp.STATS_URL 	+ "/stats2?p=" + __acpParams.PARTNER_ID + "&r=" + Math.random() + "&v=" + __acp.CLIENT_VER;			
		var is_usage_stats=false;
		switch (key)	{
			case __acp.STATS_USE_RELATED:	url += '&rel_use=1';	is_usage_stats=true;	break;
			case __acp.STATS_USE_POP:		url += '&pop_use=1';	is_usage_stats=true;	break;
			case __acp.STATS_USE_HISTORY:	url += '&his_use=1';	is_usage_stats=true;	break;
			case __acp.STATS_USE_TYPED:		url += '&typ_use=1';	is_usage_stats=true;	break;
			default:
				// Webpage views stats... don't ping the server if there's no local storage option...
				if (flash_supported == false)	{	return;	}					
				break;
		}
		if (is_usage_stats)	{
			do_reporting_to_stats_server(url);
			api_incr_search_box_cnt();
			return;
		}

		if (__acp.porn_site || flash_supported==false)	{
			return;
		}
		
		var key = __acp.LOCAL_COOKIE_STATS_BASE + key;
		__acp_log(key);	
		var cur_val = api_db_get( key, true );
		var new_val = 0;
		if (typeof cur_val != "undefined" && cur_val != null && cur_val != '' && isNaN(cur_val)==false )	{	new_val = parseInt(cur_val, 10);	}
		new_val = new_val + 1;
		api_db_set( key, new_val, true);
		
		// Check if need to update server.. 
		// 1. Upon install or after 24hrs interval...
		var cur_seconds 	= parseInt( new Date().getTime() / 1000, 10);	// since 1970...		
		var db_last_update  = parseInt( api_db_get(__acp.LOCAL_COOKIE_STATS_BASE + __acp.LAST_SUBMIT, true), 10);
		__acp_log(cur_seconds + ' vs. ' + db_last_update + ' = ' + (cur_seconds - db_last_update));

		// 0. first-time install					
		if (typeof db_last_update === 'undefined' || db_last_update == null || db_last_update == 0 || db_last_update == '' || isNaN(db_last_update))	{			
			__acp_log('initializing: ' + __acp.LOCAL_COOKIE_STATS_BASE + __acp.LAST_SUBMIT + ' = '+cur_seconds);
			// api_send_stats_to_server_clients( key );  // Nov. 06 - don't send d=0 events...
			return;
		}	else	{
			// check if the time has come to submit...
			// 1. 24hrs interval
			if (cur_seconds - db_last_update > __acp.LOCAL_COOKIE_STATS_UPDATE_FREQUENCY_SEC)	{ 
				__acp_log('api_send_stats_to_server...');									
				api_send_stats_to_server_clients( key );	
				api_send_stats_to_server();
				return;
			}													
		}
	}
	
	function api_get_days_since_install()	{
		var cur_seconds 	= parseInt( new Date().getTime() / 1000, 10);	// since 1970...		
		var db_first_update = parseInt( api_db_get(__acp.LOCAL_COOKIE_STATS_BASE + __acp.FIRST_SUBMIT, true), 10);		
		if (typeof db_first_update === 'undefined' || db_first_update == null || db_first_update == 0 || db_first_update == '' || isNaN(db_first_update))	{
			api_db_set(__acp.LOCAL_COOKIE_STATS_BASE + __acp.FIRST_SUBMIT, cur_seconds.toString(), true);					
			return 0;
		}
		return parseInt( (cur_seconds - db_first_update)/(60*60*24), 10);	
	}
	
	function api_send_stats_to_server_clients( key )	{
		var day_diff = api_get_days_since_install();
		__acp_log('api_send_stats_to_server_clients: ' + day_diff);	
		try	{			
			var is_disabled = api_db_get( __acp.ACP_DISABLED_KEY_GENERAL, true );	
			if (typeof is_disabled != 'undefined' && is_disabled != null && is_disabled != '' && is_disabled > 0)	{
				// disabled client
				day_diff = -1;						
			}			
			
			var url = encodeURI( __acp.STATS_URL 	+ "/stats2_clients?p=" + __acpParams.PARTNER_ID + "&d=" + day_diff + "&v=" + __acp.CLIENT_VER + "&t=" + __acp.profile_type); 
			do_reporting_to_stats_server( url );
			
			var cur_seconds 	= parseInt( new Date().getTime() / 1000, 10);	// since 1970...		
			api_db_set(__acp.LOCAL_COOKIE_STATS_BASE + __acp.LAST_SUBMIT, cur_seconds.toString(), true);			
			
		}	catch (e)	{
			__acp_log('api_send_stats_to_server_clients exception');
		}
	}				
	
	function sanitize_db_value(stats_value)	{
		if ( typeof stats_value === 'undefined' || stats_value==null || isNaN(stats_value) || stats_value=='' )	{	return 0;	}				
		return parseInt(stats_value, 10);				
	}
	
	function api_send_stats_to_server()	{		
		var pop_use = sanitize_db_value(api_db_get(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_USE_POP, true));	
		var his_use = sanitize_db_value(api_db_get(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_USE_HISTORY, true));
		var rel_use = sanitize_db_value(api_db_get(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_USE_RELATED, true));		
		var typ_use	= sanitize_db_value(api_db_get(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_USE_TYPED, true));			
				
		var sup_site = sanitize_db_value(api_db_get(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_SITE_SUPPORTED, true));	
		var nop_site = sanitize_db_value(api_db_get(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_SITE_NOT_SUPPORTED, true));
		var new_site = sanitize_db_value(api_db_get(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_SITE_NEW, true));			
		var irr_site = sanitize_db_value(api_db_get(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_SITE_IRRELEVANT, true));		

		if (pop_use!=0 || his_use!=0 || rel_use!=0 || typ_use!=0 || sup_site!=0 || nop_site!=0 || new_site!=0 || irr_site!==0)	{
			var url = __acp.STATS_URL 	+ "/stats2?p=" + __acpParams.PARTNER_ID + "&r=" + Math.random() + "&v=" + __acp.CLIENT_VER;
			if (pop_use !=0)	url += "&pop_use="  + (pop_use);
			if (his_use !=0)	url += "&his_use="  + (his_use);
			if (rel_use !=0)	url += "&rel_use="  + (rel_use);
			if (typ_use !=0)	url += "&typ_use="  + (typ_use);
			if (sup_site !=0)	url += "&sup_site=" + (sup_site);
			if (nop_site !=0)	url += "&nop_site=" + (nop_site);
			if (new_site !=0)	url += "&new_site=" + (new_site);
			if (irr_site !=0)	url += "&irr_site=" + (irr_site);
			url = encodeURI( url );
			do_reporting_to_stats_server(url);
		}
	
		api_db_set(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_USE_POP,0, true);
		api_db_set(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_USE_HISTORY,0, true);
		api_db_set(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_USE_RELATED,0, true);
		api_db_set(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_USE_TYPED,0, true);
				
		api_db_set(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_SITE_SUPPORTED,0, true);
		api_db_set(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_SITE_NOT_SUPPORTED,0, true);
		api_db_set(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_SITE_NEW,0, true);
		api_db_set(__acp.LOCAL_COOKIE_STATS_BASE + __acp.STATS_SITE_IRRELEVANT,0, true);							
	}	
				
	
	// API Platform Specific  [END]
	//////////////////////////////////////////////////////////////////////////////////////////
	function incr_counter_incr( key )	{	
		setTimeout(function()	{
			var cur_cnt = api_db_get( key, true );
			if (typeof cur_cnt == 'undefined' || cur_cnt == null || cur_cnt == '')	{	
				cur_cnt = 1;
			}	else	{	
				cur_cnt = parseInt(cur_cnt, 10) + 1;	
			}
			api_db_set( key, cur_cnt.toString(), true);	
		}, api_db_global_store_wait_ms);
	}
	function api_incr_search_clone_cnt()	{
		incr_counter_incr( __acp.SEARCH_CLONE_CNT );	
	}
	function api_incr_search_box_cnt()	{
		incr_counter_incr( __acp.SEARCH_BOX_CNT );	
	}
	function api_get_search_clone_cnt()	{
		var ret = parseInt( api_db_get(__acp.SEARCH_CLONE_CNT, true), 10);		
		if (typeof ret == 'undefined' || ret == null || ret == '' || isNaN(ret) )	{	ret = 0;	}
		return ret;
	}
	function api_get_search_box_cnt()	{
		var ret = parseInt( api_db_get(__acp.SEARCH_BOX_CNT, true), 10);		
		if (typeof ret == 'undefined' || ret == null || ret == '' || isNaN(ret) )	{	ret = 0;	}
		return ret;		
	}	
	function api_getToolbarId()	{
		return '';
	}

	var __acpParams =	{
		// APP_ID:						null,			// 	App ID within a platform like Crossrider	(e.g. "3915")
		// APP_ID_PARAM:				null,			//	Param name to be send in the stats and search destination	(e.g. "id")
		PARTNER_ID:					'softonicmm',
		footer_tooltip:				'Powered by AutoComplete+',
		footer_html:				'[?]',		// '[?]';	// <img border=0  src='https://clients-ssl.autocompleteplus.com/Conduit/img/acp_help.png'/>
		footer_css:					'background-image:none;list-style:none;float:right;font:10px arial, helvetica, sans-serif',	
		related_suggest_tooltip:	' - Web search',
		popular_suggest_tooltip:	' - Popular site search',
		history_suggest_tooltip:	' - Personal history',
		amazon_suggest_tooltip:		' - Amazon related',		
		focus_on_searchbox:			false,
		open_suggestions_on_focus:	true,		
		MIN_SUGGEST_WIDTH:			200,
		MIN_SUGGEST_FORM_WIDTH:		550,		
		MAX_SUGGEST_WIDTH:			800,
		PORN_FILTER:				false,
		
		what_you_type_suggestion:		true,	
		what_you_type_position_first:	true,
					
		// Web Related Suggestions Separator
		suggest_diff_style:		'desc',				//	'desc', 'line', 'none'
		suggest_diff_text_rel:	"Web search",
		suggest_diff_text_pop:	"Site search",
		suggest_diff_text_his:	"Site history",		
		
		global_search_portals_popular_ratio: 0.4	
	};

}	

/*
	acp_core_jquery_and_jqueryui.js
	Used in all platform standalone solution that lack built-in support for jQuery and jQueryUI
	(c) 2012 Cloud Power LLC
*/

/*! jQuery v1.7.1 jquery.com | jquery.org/license */
(function(a,b){function cy(a){return f.isWindow(a)?a:a.nodeType===9?a.defaultView||a.parentWindow:!1}function cv(a){if(!ck[a]){var b=c.body,d=f("<"+a+">").appendTo(b),e=d.css("display");d.remove();if(e==="none"||e===""){cl||(cl=c.createElement("iframe"),cl.frameBorder=cl.width=cl.height=0),b.appendChild(cl);if(!cm||!cl.createElement)cm=(cl.contentWindow||cl.contentDocument).document,cm.write((c.compatMode==="CSS1Compat"?"<!doctype html>":"")+"<html><body>"),cm.close();d=cm.createElement(a),cm.body.appendChild(d),e=f.css(d,"display"),b.removeChild(cl)}ck[a]=e}return ck[a]}function cu(a,b){var c={};f.each(cq.concat.apply([],cq.slice(0,b)),function(){c[this]=a});return c}function ct(){cr=b}function cs(){setTimeout(ct,0);return cr=f.now()}function cj(){try{return new a.ActiveXObject("Microsoft.XMLHTTP")}catch(b){}}function ci(){try{return new a.XMLHttpRequest}catch(b){}}function cc(a,c){a.dataFilter&&(c=a.dataFilter(c,a.dataType));var d=a.dataTypes,e={},g,h,i=d.length,j,k=d[0],l,m,n,o,p;for(g=1;g<i;g++){if(g===1)for(h in a.converters)typeof h=="string"&&(e[h.toLowerCase()]=a.converters[h]);l=k,k=d[g];if(k==="*")k=l;else if(l!=="*"&&l!==k){m=l+" "+k,n=e[m]||e["* "+k];if(!n){p=b;for(o in e){j=o.split(" ");if(j[0]===l||j[0]==="*"){p=e[j[1]+" "+k];if(p){o=e[o],o===!0?n=p:p===!0&&(n=o);break}}}}!n&&!p&&f.error("No conversion from "+m.replace(" "," to ")),n!==!0&&(c=n?n(c):p(o(c)))}}return c}function cb(a,c,d){var e=a.contents,f=a.dataTypes,g=a.responseFields,h,i,j,k;for(i in g)i in d&&(c[g[i]]=d[i]);while(f[0]==="*")f.shift(),h===b&&(h=a.mimeType||c.getResponseHeader("content-type"));if(h)for(i in e)if(e[i]&&e[i].test(h)){f.unshift(i);break}if(f[0]in d)j=f[0];else{for(i in d){if(!f[0]||a.converters[i+" "+f[0]]){j=i;break}k||(k=i)}j=j||k}if(j){j!==f[0]&&f.unshift(j);return d[j]}}function ca(a,b,c,d){if(f.isArray(b))f.each(b,function(b,e){c||bE.test(a)?d(a,e):ca(a+"["+(typeof e=="object"||f.isArray(e)?b:"")+"]",e,c,d)});else if(!c&&b!=null&&typeof b=="object")for(var e in b)ca(a+"["+e+"]",b[e],c,d);else d(a,b)}function b_(a,c){var d,e,g=f.ajaxSettings.flatOptions||{};for(d in c)c[d]!==b&&((g[d]?a:e||(e={}))[d]=c[d]);e&&f.extend(!0,a,e)}function b$(a,c,d,e,f,g){f=f||c.dataTypes[0],g=g||{},g[f]=!0;var h=a[f],i=0,j=h?h.length:0,k=a===bT,l;for(;i<j&&(k||!l);i++)l=h[i](c,d,e),typeof l=="string"&&(!k||g[l]?l=b:(c.dataTypes.unshift(l),l=b$(a,c,d,e,l,g)));(k||!l)&&!g["*"]&&(l=b$(a,c,d,e,"*",g));return l}function bZ(a){return function(b,c){typeof b!="string"&&(c=b,b="*");if(f.isFunction(c)){var d=b.toLowerCase().split(bP),e=0,g=d.length,h,i,j;for(;e<g;e++)h=d[e],j=/^\+/.test(h),j&&(h=h.substr(1)||"*"),i=a[h]=a[h]||[],i[j?"unshift":"push"](c)}}}function bC(a,b,c){var d=b==="width"?a.offsetWidth:a.offsetHeight,e=b==="width"?bx:by,g=0,h=e.length;if(d>0){if(c!=="border")for(;g<h;g++)c||(d-=parseFloat(f.css(a,"padding"+e[g]))||0),c==="margin"?d+=parseFloat(f.css(a,c+e[g]))||0:d-=parseFloat(f.css(a,"border"+e[g]+"Width"))||0;return d+"px"}d=bz(a,b,b);if(d<0||d==null)d=a.style[b]||0;d=parseFloat(d)||0;if(c)for(;g<h;g++)d+=parseFloat(f.css(a,"padding"+e[g]))||0,c!=="padding"&&(d+=parseFloat(f.css(a,"border"+e[g]+"Width"))||0),c==="margin"&&(d+=parseFloat(f.css(a,c+e[g]))||0);return d+"px"}function bp(a,b){b.src?f.ajax({url:b.src,async:!1,dataType:"script"}):f.globalEval((b.text||b.textContent||b.innerHTML||"").replace(bf,"/*$0*/")),b.parentNode&&b.parentNode.removeChild(b)}function bo(a){var b=c.createElement("div");bh.appendChild(b),b.innerHTML=a.outerHTML;return b.firstChild}function bn(a){var b=(a.nodeName||"").toLowerCase();b==="input"?bm(a):b!=="script"&&typeof a.getElementsByTagName!="undefined"&&f.grep(a.getElementsByTagName("input"),bm)}function bm(a){if(a.type==="checkbox"||a.type==="radio")a.defaultChecked=a.checked}function bl(a){return typeof a.getElementsByTagName!="undefined"?a.getElementsByTagName("*"):typeof a.querySelectorAll!="undefined"?a.querySelectorAll("*"):[]}function bk(a,b){var c;if(b.nodeType===1){b.clearAttributes&&b.clearAttributes(),b.mergeAttributes&&b.mergeAttributes(a),c=b.nodeName.toLowerCase();if(c==="object")b.outerHTML=a.outerHTML;else if(c!=="input"||a.type!=="checkbox"&&a.type!=="radio"){if(c==="option")b.selected=a.defaultSelected;else if(c==="input"||c==="textarea")b.defaultValue=a.defaultValue}else a.checked&&(b.defaultChecked=b.checked=a.checked),b.value!==a.value&&(b.value=a.value);b.removeAttribute(f.expando)}}function bj(a,b){if(b.nodeType===1&&!!f.hasData(a)){var c,d,e,g=f._data(a),h=f._data(b,g),i=g.events;if(i){delete h.handle,h.events={};for(c in i)for(d=0,e=i[c].length;d<e;d++)f.event.add(b,c+(i[c][d].namespace?".":"")+i[c][d].namespace,i[c][d],i[c][d].data)}h.data&&(h.data=f.extend({},h.data))}}function bi(a,b){return f.nodeName(a,"table")?a.getElementsByTagName("tbody")[0]||a.appendChild(a.ownerDocument.createElement("tbody")):a}function U(a){var b=V.split("|"),c=a.createDocumentFragment();if(c.createElement)while(b.length)c.createElement(b.pop());return c}function T(a,b,c){b=b||0;if(f.isFunction(b))return f.grep(a,function(a,d){var e=!!b.call(a,d,a);return e===c});if(b.nodeType)return f.grep(a,function(a,d){return a===b===c});if(typeof b=="string"){var d=f.grep(a,function(a){return a.nodeType===1});if(O.test(b))return f.filter(b,d,!c);b=f.filter(b,d)}return f.grep(a,function(a,d){return f.inArray(a,b)>=0===c})}function S(a){return!a||!a.parentNode||a.parentNode.nodeType===11}function K(){return!0}function J(){return!1}function n(a,b,c){var d=b+"defer",e=b+"queue",g=b+"mark",h=f._data(a,d);h&&(c==="queue"||!f._data(a,e))&&(c==="mark"||!f._data(a,g))&&setTimeout(function(){!f._data(a,e)&&!f._data(a,g)&&(f.removeData(a,d,!0),h.fire())},0)}function m(a){for(var b in a){if(b==="data"&&f.isEmptyObject(a[b]))continue;if(b!=="toJSON")return!1}return!0}function l(a,c,d){if(d===b&&a.nodeType===1){var e="data-"+c.replace(k,"-$1").toLowerCase();d=a.getAttribute(e);if(typeof d=="string"){try{d=d==="true"?!0:d==="false"?!1:d==="null"?null:f.isNumeric(d)?parseFloat(d):j.test(d)?f.parseJSON(d):d}catch(g){}f.data(a,c,d)}else d=b}return d}function h(a){var b=g[a]={},c,d;a=a.split(/\s+/);for(c=0,d=a.length;c<d;c++)b[a[c]]=!0;return b}var c=a.document,d=a.navigator,e=a.location,f=function(){function J(){if(!e.isReady){try{c.documentElement.doScroll("left")}catch(a){setTimeout(J,1);return}e.ready()}}var e=function(a,b){return new e.fn.init(a,b,h)},f=a.jQuery,g=a.$,h,i=/^(?:[^#<]*(<[\w\W]+>)[^>]*$|#([\w\-]*)$)/,j=/\S/,k=/^\s+/,l=/\s+$/,m=/^<(\w+)\s*\/?>(?:<\/\1>)?$/,n=/^[\],:{}\s]*$/,o=/\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g,p=/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g,q=/(?:^|:|,)(?:\s*\[)+/g,r=/(webkit)[ \/]([\w.]+)/,s=/(opera)(?:.*version)?[ \/]([\w.]+)/,t=/(msie) ([\w.]+)/,u=/(mozilla)(?:.*? rv:([\w.]+))?/,v=/-([a-z]|[0-9])/ig,w=/^-ms-/,x=function(a,b){return(b+"").toUpperCase()},y=d.userAgent,z,A,B,C=Object.prototype.toString,D=Object.prototype.hasOwnProperty,E=Array.prototype.push,F=Array.prototype.slice,G=String.prototype.trim,H=Array.prototype.indexOf,I={};e.fn=e.prototype={constructor:e,init:function(a,d,f){var g,h,j,k;if(!a)return this;if(a.nodeType){this.context=this[0]=a,this.length=1;return this}if(a==="body"&&!d&&c.body){this.context=c,this[0]=c.body,this.selector=a,this.length=1;return this}if(typeof a=="string"){a.charAt(0)!=="<"||a.charAt(a.length-1)!==">"||a.length<3?g=i.exec(a):g=[null,a,null];if(g&&(g[1]||!d)){if(g[1]){d=d instanceof e?d[0]:d,k=d?d.ownerDocument||d:c,j=m.exec(a),j?e.isPlainObject(d)?(a=[c.createElement(j[1])],e.fn.attr.call(a,d,!0)):a=[k.createElement(j[1])]:(j=e.buildFragment([g[1]],[k]),a=(j.cacheable?e.clone(j.fragment):j.fragment).childNodes);return e.merge(this,a)}h=c.getElementById(g[2]);if(h&&h.parentNode){if(h.id!==g[2])return f.find(a);this.length=1,this[0]=h}this.context=c,this.selector=a;return this}return!d||d.jquery?(d||f).find(a):this.constructor(d).find(a)}if(e.isFunction(a))return f.ready(a);a.selector!==b&&(this.selector=a.selector,this.context=a.context);return e.makeArray(a,this)},selector:"",jquery:"1.7.1",length:0,size:function(){return this.length},toArray:function(){return F.call(this,0)},get:function(a){return a==null?this.toArray():a<0?this[this.length+a]:this[a]},pushStack:function(a,b,c){var d=this.constructor();e.isArray(a)?E.apply(d,a):e.merge(d,a),d.prevObject=this,d.context=this.context,b==="find"?d.selector=this.selector+(this.selector?" ":"")+c:b&&(d.selector=this.selector+"."+b+"("+c+")");return d},each:function(a,b){return e.each(this,a,b)},ready:function(a){e.bindReady(),A.add(a);return this},eq:function(a){a=+a;return a===-1?this.slice(a):this.slice(a,a+1)},first:function(){return this.eq(0)},last:function(){return this.eq(-1)},slice:function(){return this.pushStack(F.apply(this,arguments),"slice",F.call(arguments).join(","))},map:function(a){return this.pushStack(e.map(this,function(b,c){return a.call(b,c,b)}))},end:function(){return this.prevObject||this.constructor(null)},push:E,sort:[].sort,splice:[].splice},e.fn.init.prototype=e.fn,e.extend=e.fn.extend=function(){var a,c,d,f,g,h,i=arguments[0]||{},j=1,k=arguments.length,l=!1;typeof i=="boolean"&&(l=i,i=arguments[1]||{},j=2),typeof i!="object"&&!e.isFunction(i)&&(i={}),k===j&&(i=this,--j);for(;j<k;j++)if((a=arguments[j])!=null)for(c in a){d=i[c],f=a[c];if(i===f)continue;l&&f&&(e.isPlainObject(f)||(g=e.isArray(f)))?(g?(g=!1,h=d&&e.isArray(d)?d:[]):h=d&&e.isPlainObject(d)?d:{},i[c]=e.extend(l,h,f)):f!==b&&(i[c]=f)}return i},e.extend({noConflict:function(b){a.$===e&&(a.$=g),b&&a.jQuery===e&&(a.jQuery=f);return e},isReady:!1,readyWait:1,holdReady:function(a){a?e.readyWait++:e.ready(!0)},ready:function(a){if(a===!0&&!--e.readyWait||a!==!0&&!e.isReady){if(!c.body)return setTimeout(e.ready,1);e.isReady=!0;if(a!==!0&&--e.readyWait>0)return;A.fireWith(c,[e]),e.fn.trigger&&e(c).trigger("ready").off("ready")}},bindReady:function(){if(!A){A=e.Callbacks("once memory");if(c.readyState==="complete")return setTimeout(e.ready,1);if(c.addEventListener)c.addEventListener("DOMContentLoaded",B,!1),a.addEventListener("load",e.ready,!1);else if(c.attachEvent){c.attachEvent("onreadystatechange",B),a.attachEvent("onload",e.ready);var b=!1;try{b=a.frameElement==null}catch(d){}c.documentElement.doScroll&&b&&J()}}},isFunction:function(a){return e.type(a)==="function"},isArray:Array.isArray||function(a){return e.type(a)==="array"},isWindow:function(a){return a&&typeof a=="object"&&"setInterval"in a},isNumeric:function(a){return!isNaN(parseFloat(a))&&isFinite(a)},type:function(a){return a==null?String(a):I[C.call(a)]||"object"},isPlainObject:function(a){if(!a||e.type(a)!=="object"||a.nodeType||e.isWindow(a))return!1;try{if(a.constructor&&!D.call(a,"constructor")&&!D.call(a.constructor.prototype,"isPrototypeOf"))return!1}catch(c){return!1}var d;for(d in a);return d===b||D.call(a,d)},isEmptyObject:function(a){for(var b in a)return!1;return!0},error:function(a){throw new Error(a)},parseJSON:function(b){if(typeof b!="string"||!b)return null;b=e.trim(b);if(a.JSON&&a.JSON.parse)return a.JSON.parse(b);if(n.test(b.replace(o,"@").replace(p,"]").replace(q,"")))return(new Function("return "+b))();e.error("Invalid JSON: "+b)},parseXML:function(c){var d,f;try{a.DOMParser?(f=new DOMParser,d=f.parseFromString(c,"text/xml")):(d=new ActiveXObject("Microsoft.XMLDOM"),d.async="false",d.loadXML(c))}catch(g){d=b}(!d||!d.documentElement||d.getElementsByTagName("parsererror").length)&&e.error("Invalid XML: "+c);return d},noop:function(){},globalEval:function(b){b&&j.test(b)&&(a.execScript||function(b){a.eval.call(a,b)})(b)},camelCase:function(a){return a.replace(w,"ms-").replace(v,x)},nodeName:function(a,b){return a.nodeName&&a.nodeName.toUpperCase()===b.toUpperCase()},each:function(a,c,d){var f,g=0,h=a.length,i=h===b||e.isFunction(a);if(d){if(i){for(f in a)if(c.apply(a[f],d)===!1)break}else for(;g<h;)if(c.apply(a[g++],d)===!1)break}else if(i){for(f in a)if(c.call(a[f],f,a[f])===!1)break}else for(;g<h;)if(c.call(a[g],g,a[g++])===!1)break;return a},trim:G?function(a){return a==null?"":G.call(a)}:function(a){return a==null?"":(a+"").replace(k,"").replace(l,"")},makeArray:function(a,b){var c=b||[];if(a!=null){var d=e.type(a);a.length==null||d==="string"||d==="function"||d==="regexp"||e.isWindow(a)?E.call(c,a):e.merge(c,a)}return c},inArray:function(a,b,c){var d;if(b){if(H)return H.call(b,a,c);d=b.length,c=c?c<0?Math.max(0,d+c):c:0;for(;c<d;c++)if(c in b&&b[c]===a)return c}return-1},merge:function(a,c){var d=a.length,e=0;if(typeof c.length=="number")for(var f=c.length;e<f;e++)a[d++]=c[e];else while(c[e]!==b)a[d++]=c[e++];a.length=d;return a},grep:function(a,b,c){var d=[],e;c=!!c;for(var f=0,g=a.length;f<g;f++)e=!!b(a[f],f),c!==e&&d.push(a[f]);return d},map:function(a,c,d){var f,g,h=[],i=0,j=a.length,k=a instanceof e||j!==b&&typeof j=="number"&&(j>0&&a[0]&&a[j-1]||j===0||e.isArray(a));if(k)for(;i<j;i++)f=c(a[i],i,d),f!=null&&(h[h.length]=f);else for(g in a)f=c(a[g],g,d),f!=null&&(h[h.length]=f);return h.concat.apply([],h)},guid:1,proxy:function(a,c){if(typeof c=="string"){var d=a[c];c=a,a=d}if(!e.isFunction(a))return b;var f=F.call(arguments,2),g=function(){return a.apply(c,f.concat(F.call(arguments)))};g.guid=a.guid=a.guid||g.guid||e.guid++;return g},access:function(a,c,d,f,g,h){var i=a.length;if(typeof c=="object"){for(var j in c)e.access(a,j,c[j],f,g,d);return a}if(d!==b){f=!h&&f&&e.isFunction(d);for(var k=0;k<i;k++)g(a[k],c,f?d.call(a[k],k,g(a[k],c)):d,h);return a}return i?g(a[0],c):b},now:function(){return(new Date).getTime()},uaMatch:function(a){a=a.toLowerCase();var b=r.exec(a)||s.exec(a)||t.exec(a)||a.indexOf("compatible")<0&&u.exec(a)||[];return{browser:b[1]||"",version:b[2]||"0"}},sub:function(){function a(b,c){return new a.fn.init(b,c)}e.extend(!0,a,this),a.superclass=this,a.fn=a.prototype=this(),a.fn.constructor=a,a.sub=this.sub,a.fn.init=function(d,f){f&&f instanceof e&&!(f instanceof a)&&(f=a(f));return e.fn.init.call(this,d,f,b)},a.fn.init.prototype=a.fn;var b=a(c);return a},browser:{}}),e.each("Boolean Number String Function Array Date RegExp Object".split(" "),function(a,b){I["[object "+b+"]"]=b.toLowerCase()}),z=e.uaMatch(y),z.browser&&(e.browser[z.browser]=!0,e.browser.version=z.version),e.browser.webkit&&(e.browser.safari=!0),j.test(" ")&&(k=/^[\s\xA0]+/,l=/[\s\xA0]+$/),h=e(c),c.addEventListener?B=function(){c.removeEventListener("DOMContentLoaded",B,!1),e.ready()}:c.attachEvent&&(B=function(){c.readyState==="complete"&&(c.detachEvent("onreadystatechange",B),e.ready())});return e}(),g={};f.Callbacks=function(a){a=a?g[a]||h(a):{};var c=[],d=[],e,i,j,k,l,m=function(b){var d,e,g,h,i;for(d=0,e=b.length;d<e;d++)g=b[d],h=f.type(g),h==="array"?m(g):h==="function"&&(!a.unique||!o.has(g))&&c.push(g)},n=function(b,f){f=f||[],e=!a.memory||[b,f],i=!0,l=j||0,j=0,k=c.length;for(;c&&l<k;l++)if(c[l].apply(b,f)===!1&&a.stopOnFalse){e=!0;break}i=!1,c&&(a.once?e===!0?o.disable():c=[]:d&&d.length&&(e=d.shift(),o.fireWith(e[0],e[1])))},o={add:function(){if(c){var a=c.length;m(arguments),i?k=c.length:e&&e!==!0&&(j=a,n(e[0],e[1]))}return this},remove:function(){if(c){var b=arguments,d=0,e=b.length;for(;d<e;d++)for(var f=0;f<c.length;f++)if(b[d]===c[f]){i&&f<=k&&(k--,f<=l&&l--),c.splice(f--,1);if(a.unique)break}}return this},has:function(a){if(c){var b=0,d=c.length;for(;b<d;b++)if(a===c[b])return!0}return!1},empty:function(){c=[];return this},disable:function(){c=d=e=b;return this},disabled:function(){return!c},lock:function(){d=b,(!e||e===!0)&&o.disable();return this},locked:function(){return!d},fireWith:function(b,c){d&&(i?a.once||d.push([b,c]):(!a.once||!e)&&n(b,c));return this},fire:function(){o.fireWith(this,arguments);return this},fired:function(){return!!e}};return o};var i=[].slice;f.extend({Deferred:function(a){var b=f.Callbacks("once memory"),c=f.Callbacks("once memory"),d=f.Callbacks("memory"),e="pending",g={resolve:b,reject:c,notify:d},h={done:b.add,fail:c.add,progress:d.add,state:function(){return e},isResolved:b.fired,isRejected:c.fired,then:function(a,b,c){i.done(a).fail(b).progress(c);return this},always:function(){i.done.apply(i,arguments).fail.apply(i,arguments);return this},pipe:function(a,b,c){return f.Deferred(function(d){f.each({done:[a,"resolve"],fail:[b,"reject"],progress:[c,"notify"]},function(a,b){var c=b[0],e=b[1],g;f.isFunction(c)?i[a](function(){g=c.apply(this,arguments),g&&f.isFunction(g.promise)?g.promise().then(d.resolve,d.reject,d.notify):d[e+"With"](this===i?d:this,[g])}):i[a](d[e])})}).promise()},promise:function(a){if(a==null)a=h;else for(var b in h)a[b]=h[b];return a}},i=h.promise({}),j;for(j in g)i[j]=g[j].fire,i[j+"With"]=g[j].fireWith;i.done(function(){e="resolved"},c.disable,d.lock).fail(function(){e="rejected"},b.disable,d.lock),a&&a.call(i,i);return i},when:function(a){function m(a){return function(b){e[a]=arguments.length>1?i.call(arguments,0):b,j.notifyWith(k,e)}}function l(a){return function(c){b[a]=arguments.length>1?i.call(arguments,0):c,--g||j.resolveWith(j,b)}}var b=i.call(arguments,0),c=0,d=b.length,e=Array(d),g=d,h=d,j=d<=1&&a&&f.isFunction(a.promise)?a:f.Deferred(),k=j.promise();if(d>1){for(;c<d;c++)b[c]&&b[c].promise&&f.isFunction(b[c].promise)?b[c].promise().then(l(c),j.reject,m(c)):--g;g||j.resolveWith(j,b)}else j!==a&&j.resolveWith(j,d?[a]:[]);return k}}),f.support=function(){var b,d,e,g,h,i,j,k,l,m,n,o,p,q=c.createElement("div"),r=c.documentElement;q.setAttribute("className","t"),q.innerHTML="   <link/><table></table><a href='/a' style='top:1px;float:left;opacity:.55;'>a</a><input type='checkbox'/>",d=q.getElementsByTagName("*"),e=q.getElementsByTagName("a")[0];if(!d||!d.length||!e)return{};g=c.createElement("select"),h=g.appendChild(c.createElement("option")),i=q.getElementsByTagName("input")[0],b={leadingWhitespace:q.firstChild.nodeType===3,tbody:!q.getElementsByTagName("tbody").length,htmlSerialize:!!q.getElementsByTagName("link").length,style:/top/.test(e.getAttribute("style")),hrefNormalized:e.getAttribute("href")==="/a",opacity:/^0.55/.test(e.style.opacity),cssFloat:!!e.style.cssFloat,checkOn:i.value==="on",optSelected:h.selected,getSetAttribute:q.className!=="t",enctype:!!c.createElement("form").enctype,html5Clone:c.createElement("nav").cloneNode(!0).outerHTML!=="<:nav></:nav>",submitBubbles:!0,changeBubbles:!0,focusinBubbles:!1,deleteExpando:!0,noCloneEvent:!0,inlineBlockNeedsLayout:!1,shrinkWrapBlocks:!1,reliableMarginRight:!0},i.checked=!0,b.noCloneChecked=i.cloneNode(!0).checked,g.disabled=!0,b.optDisabled=!h.disabled;try{delete q.test}catch(s){b.deleteExpando=!1}!q.addEventListener&&q.attachEvent&&q.fireEvent&&(q.attachEvent("onclick",function(){b.noCloneEvent=!1}),q.cloneNode(!0).fireEvent("onclick")),i=c.createElement("input"),i.value="t",i.setAttribute("type","radio"),b.radioValue=i.value==="t",i.setAttribute("checked","checked"),q.appendChild(i),k=c.createDocumentFragment(),k.appendChild(q.lastChild),b.checkClone=k.cloneNode(!0).cloneNode(!0).lastChild.checked,b.appendChecked=i.checked,k.removeChild(i),k.appendChild(q),q.innerHTML="",a.getComputedStyle&&(j=c.createElement("div"),j.style.width="0",j.style.marginRight="0",q.style.width="2px",q.appendChild(j),b.reliableMarginRight=(parseInt((a.getComputedStyle(j,null)||{marginRight:0}).marginRight,10)||0)===0);if(q.attachEvent)for(o in{submit:1,change:1,focusin:1})n="on"+o,p=n in q,p||(q.setAttribute(n,"return;"),p=typeof q[n]=="function"),b[o+"Bubbles"]=p;k.removeChild(q),k=g=h=j=q=i=null,f(function(){var a,d,e,g,h,i,j,k,m,n,o,r=c.getElementsByTagName("body")[0];!r||(j=1,k="position:absolute;top:0;left:0;width:1px;height:1px;margin:0;",m="visibility:hidden;border:0;",n="style='"+k+"border:5px solid #000;padding:0;'",o="<div "+n+"><div></div></div>"+"<table "+n+" cellpadding='0' cellspacing='0'>"+"<tr><td></td></tr></table>",a=c.createElement("div"),a.style.cssText=m+"width:0;height:0;position:static;top:0;margin-top:"+j+"px",r.insertBefore(a,r.firstChild),q=c.createElement("div"),a.appendChild(q),q.innerHTML="<table><tr><td style='padding:0;border:0;display:none'></td><td>t</td></tr></table>",l=q.getElementsByTagName("td"),p=l[0].offsetHeight===0,l[0].style.display="",l[1].style.display="none",b.reliableHiddenOffsets=p&&l[0].offsetHeight===0,q.innerHTML="",q.style.width=q.style.paddingLeft="1px",f.boxModel=b.boxModel=q.offsetWidth===2,typeof q.style.zoom!="undefined"&&(q.style.display="inline",q.style.zoom=1,b.inlineBlockNeedsLayout=q.offsetWidth===2,q.style.display="",q.innerHTML="<div style='width:4px;'></div>",b.shrinkWrapBlocks=q.offsetWidth!==2),q.style.cssText=k+m,q.innerHTML=o,d=q.firstChild,e=d.firstChild,h=d.nextSibling.firstChild.firstChild,i={doesNotAddBorder:e.offsetTop!==5,doesAddBorderForTableAndCells:h.offsetTop===5},e.style.position="fixed",e.style.top="20px",i.fixedPosition=e.offsetTop===20||e.offsetTop===15,e.style.position=e.style.top="",d.style.overflow="hidden",d.style.position="relative",i.subtractsBorderForOverflowNotVisible=e.offsetTop===-5,i.doesNotIncludeMarginInBodyOffset=r.offsetTop!==j,r.removeChild(a),q=a=null,f.extend(b,i))});return b}();var j=/^(?:\{.*\}|\[.*\])$/,k=/([A-Z])/g;f.extend({cache:{},uuid:0,expando:"jQuery"+(f.fn.jquery+Math.random()).replace(/\D/g,""),noData:{embed:!0,object:"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000",applet:!0},hasData:function(a){a=a.nodeType?f.cache[a[f.expando]]:a[f.expando];return!!a&&!m(a)},data:function(a,c,d,e){if(!!f.acceptData(a)){var g,h,i,j=f.expando,k=typeof c=="string",l=a.nodeType,m=l?f.cache:a,n=l?a[j]:a[j]&&j,o=c==="events";if((!n||!m[n]||!o&&!e&&!m[n].data)&&k&&d===b)return;n||(l?a[j]=n=++f.uuid:n=j),m[n]||(m[n]={},l||(m[n].toJSON=f.noop));if(typeof c=="object"||typeof c=="function")e?m[n]=f.extend(m[n],c):m[n].data=f.extend(m[n].data,c);g=h=m[n],e||(h.data||(h.data={}),h=h.data),d!==b&&(h[f.camelCase(c)]=d);if(o&&!h[c])return g.events;k?(i=h[c],i==null&&(i=h[f.camelCase(c)])):i=h;return i}},removeData:function(a,b,c){if(!!f.acceptData(a)){var d,e,g,h=f.expando,i=a.nodeType,j=i?f.cache:a,k=i?a[h]:h;if(!j[k])return;if(b){d=c?j[k]:j[k].data;if(d){f.isArray(b)||(b in d?b=[b]:(b=f.camelCase(b),b in d?b=[b]:b=b.split(" ")));for(e=0,g=b.length;e<g;e++)delete d[b[e]];if(!(c?m:f.isEmptyObject)(d))return}}if(!c){delete j[k].data;if(!m(j[k]))return}f.support.deleteExpando||!j.setInterval?delete j[k]:j[k]=null,i&&(f.support.deleteExpando?delete a[h]:a.removeAttribute?a.removeAttribute(h):a[h]=null)}},_data:function(a,b,c){return f.data(a,b,c,!0)},acceptData:function(a){if(a.nodeName){var b=f.noData[a.nodeName.toLowerCase()];if(b)return b!==!0&&a.getAttribute("classid")===b}return!0}}),f.fn.extend({data:function(a,c){var d,e,g,h=null;if(typeof a=="undefined"){if(this.length){h=f.data(this[0]);if(this[0].nodeType===1&&!f._data(this[0],"parsedAttrs")){e=this[0].attributes;for(var i=0,j=e.length;i<j;i++)g=e[i].name,g.indexOf("data-")===0&&(g=f.camelCase(g.substring(5)),l(this[0],g,h[g]));f._data(this[0],"parsedAttrs",!0)}}return h}if(typeof a=="object")return this.each(function(){f.data(this,a)});d=a.split("."),d[1]=d[1]?"."+d[1]:"";if(c===b){h=this.triggerHandler("getData"+d[1]+"!",[d[0]]),h===b&&this.length&&(h=f.data(this[0],a),h=l(this[0],a,h));return h===b&&d[1]?this.data(d[0]):h}return this.each(function(){var b=f(this),e=[d[0],c];b.triggerHandler("setData"+d[1]+"!",e),f.data(this,a,c),b.triggerHandler("changeData"+d[1]+"!",e)})},removeData:function(a){return this.each(function(){f.removeData(this,a)})}}),f.extend({_mark:function(a,b){a&&(b=(b||"fx")+"mark",f._data(a,b,(f._data(a,b)||0)+1))},_unmark:function(a,b,c){a!==!0&&(c=b,b=a,a=!1);if(b){c=c||"fx";var d=c+"mark",e=a?0:(f._data(b,d)||1)-1;e?f._data(b,d,e):(f.removeData(b,d,!0),n(b,c,"mark"))}},queue:function(a,b,c){var d;if(a){b=(b||"fx")+"queue",d=f._data(a,b),c&&(!d||f.isArray(c)?d=f._data(a,b,f.makeArray(c)):d.push(c));return d||[]}},dequeue:function(a,b){b=b||"fx";var c=f.queue(a,b),d=c.shift(),e={};d==="inprogress"&&(d=c.shift()),d&&(b==="fx"&&c.unshift("inprogress"),f._data(a,b+".run",e),d.call(a,function(){f.dequeue(a,b)},e)),c.length||(f.removeData(a,b+"queue "+b+".run",!0),n(a,b,"queue"))}}),f.fn.extend({queue:function(a,c){typeof a!="string"&&(c=a,a="fx");if(c===b)return f.queue(this[0],a);return this.each(function(){var b=f.queue(this,a,c);a==="fx"&&b[0]!=="inprogress"&&f.dequeue(this,a)})},dequeue:function(a){return this.each(function(){f.dequeue(this,a)})},delay:function(a,b){a=f.fx?f.fx.speeds[a]||a:a,b=b||"fx";return this.queue(b,function(b,c){var d=setTimeout(b,a);c.stop=function(){clearTimeout(d)}})},clearQueue:function(a){return this.queue(a||"fx",[])},promise:function(a,c){function m(){--h||d.resolveWith(e,[e])}typeof a!="string"&&(c=a,a=b),a=a||"fx";var d=f.Deferred(),e=this,g=e.length,h=1,i=a+"defer",j=a+"queue",k=a+"mark",l;while(g--)if(l=f.data(e[g],i,b,!0)||(f.data(e[g],j,b,!0)||f.data(e[g],k,b,!0))&&f.data(e[g],i,f.Callbacks("once memory"),!0))h++,l.add(m);m();return d.promise()}});var o=/[\n\t\r]/g,p=/\s+/,q=/\r/g,r=/^(?:button|input)$/i,s=/^(?:button|input|object|select|textarea)$/i,t=/^a(?:rea)?$/i,u=/^(?:autofocus|autoplay|async|checked|controls|defer|disabled|hidden|loop|multiple|open|readonly|required|scoped|selected)$/i,v=f.support.getSetAttribute,w,x,y;f.fn.extend({attr:function(a,b){return f.access(this,a,b,!0,f.attr)},removeAttr:function(a){return this.each(function(){f.removeAttr(this,a)})},prop:function(a,b){return f.access(this,a,b,!0,f.prop)},removeProp:function(a){a=f.propFix[a]||a;return this.each(function(){try{this[a]=b,delete this[a]}catch(c){}})},addClass:function(a){var b,c,d,e,g,h,i;if(f.isFunction(a))return this.each(function(b){f(this).addClass(a.call(this,b,this.className))});if(a&&typeof a=="string"){b=a.split(p);for(c=0,d=this.length;c<d;c++){e=this[c];if(e.nodeType===1)if(!e.className&&b.length===1)e.className=a;else{g=" "+e.className+" ";for(h=0,i=b.length;h<i;h++)~g.indexOf(" "+b[h]+" ")||(g+=b[h]+" ");e.className=f.trim(g)}}}return this},removeClass:function(a){var c,d,e,g,h,i,j;if(f.isFunction(a))return this.each(function(b){f(this).removeClass(a.call(this,b,this.className))});if(a&&typeof a=="string"||a===b){c=(a||"").split(p);for(d=0,e=this.length;d<e;d++){g=this[d];if(g.nodeType===1&&g.className)if(a){h=(" "+g.className+" ").replace(o," ");for(i=0,j=c.length;i<j;i++)h=h.replace(" "+c[i]+" "," ");g.className=f.trim(h)}else g.className=""}}return this},toggleClass:function(a,b){var c=typeof a,d=typeof b=="boolean";if(f.isFunction(a))return this.each(function(c){f(this).toggleClass(a.call(this,c,this.className,b),b)});return this.each(function(){if(c==="string"){var e,g=0,h=f(this),i=b,j=a.split(p);while(e=j[g++])i=d?i:!h.hasClass(e),h[i?"addClass":"removeClass"](e)}else if(c==="undefined"||c==="boolean")this.className&&f._data(this,"__className__",this.className),this.className=this.className||a===!1?"":f._data(this,"__className__")||""})},hasClass:function(a){var b=" "+a+" ",c=0,d=this.length;for(;c<d;c++)if(this[c].nodeType===1&&(" "+this[c].className+" ").replace(o," ").indexOf(b)>-1)return!0;return!1},val:function(a){var c,d,e,g=this[0];{if(!!arguments.length){e=f.isFunction(a);return this.each(function(d){var g=f(this),h;if(this.nodeType===1){e?h=a.call(this,d,g.val()):h=a,h==null?h="":typeof h=="number"?h+="":f.isArray(h)&&(h=f.map(h,function(a){return a==null?"":a+""})),c=f.valHooks[this.nodeName.toLowerCase()]||f.valHooks[this.type];if(!c||!("set"in c)||c.set(this,h,"value")===b)this.value=h}})}if(g){c=f.valHooks[g.nodeName.toLowerCase()]||f.valHooks[g.type];if(c&&"get"in c&&(d=c.get(g,"value"))!==b)return d;d=g.value;return typeof d=="string"?d.replace(q,""):d==null?"":d}}}}),f.extend({valHooks:{option:{get:function(a){var b=a.attributes.value;return!b||b.specified?a.value:a.text}},select:{get:function(a){var b,c,d,e,g=a.selectedIndex,h=[],i=a.options,j=a.type==="select-one";if(g<0)return null;c=j?g:0,d=j?g+1:i.length;for(;c<d;c++){e=i[c];if(e.selected&&(f.support.optDisabled?!e.disabled:e.getAttribute("disabled")===null)&&(!e.parentNode.disabled||!f.nodeName(e.parentNode,"optgroup"))){b=f(e).val();if(j)return b;h.push(b)}}if(j&&!h.length&&i.length)return f(i[g]).val();return h},set:function(a,b){var c=f.makeArray(b);f(a).find("option").each(function(){this.selected=f.inArray(f(this).val(),c)>=0}),c.length||(a.selectedIndex=-1);return c}}},attrFn:{val:!0,css:!0,html:!0,text:!0,data:!0,width:!0,height:!0,offset:!0},attr:function(a,c,d,e){var g,h,i,j=a.nodeType;if(!!a&&j!==3&&j!==8&&j!==2){if(e&&c in f.attrFn)return f(a)[c](d);if(typeof a.getAttribute=="undefined")return f.prop(a,c,d);i=j!==1||!f.isXMLDoc(a),i&&(c=c.toLowerCase(),h=f.attrHooks[c]||(u.test(c)?x:w));if(d!==b){if(d===null){f.removeAttr(a,c);return}if(h&&"set"in h&&i&&(g=h.set(a,d,c))!==b)return g;a.setAttribute(c,""+d);return d}if(h&&"get"in h&&i&&(g=h.get(a,c))!==null)return g;g=a.getAttribute(c);return g===null?b:g}},removeAttr:function(a,b){var c,d,e,g,h=0;if(b&&a.nodeType===1){d=b.toLowerCase().split(p),g=d.length;for(;h<g;h++)e=d[h],e&&(c=f.propFix[e]||e,f.attr(a,e,""),a.removeAttribute(v?e:c),u.test(e)&&c in a&&(a[c]=!1))}},attrHooks:{type:{set:function(a,b){if(r.test(a.nodeName)&&a.parentNode)f.error("type property can't be changed");else if(!f.support.radioValue&&b==="radio"&&f.nodeName(a,"input")){var c=a.value;a.setAttribute("type",b),c&&(a.value=c);return b}}},value:{get:function(a,b){if(w&&f.nodeName(a,"button"))return w.get(a,b);return b in a?a.value:null},set:function(a,b,c){if(w&&f.nodeName(a,"button"))return w.set(a,b,c);a.value=b}}},propFix:{tabindex:"tabIndex",readonly:"readOnly","for":"htmlFor","class":"className",maxlength:"maxLength",cellspacing:"cellSpacing",cellpadding:"cellPadding",rowspan:"rowSpan",colspan:"colSpan",usemap:"useMap",frameborder:"frameBorder",contenteditable:"contentEditable"},prop:function(a,c,d){var e,g,h,i=a.nodeType;if(!!a&&i!==3&&i!==8&&i!==2){h=i!==1||!f.isXMLDoc(a),h&&(c=f.propFix[c]||c,g=f.propHooks[c]);return d!==b?g&&"set"in g&&(e=g.set(a,d,c))!==b?e:a[c]=d:g&&"get"in g&&(e=g.get(a,c))!==null?e:a[c]}},propHooks:{tabIndex:{get:function(a){var c=a.getAttributeNode("tabindex");return c&&c.specified?parseInt(c.value,10):s.test(a.nodeName)||t.test(a.nodeName)&&a.href?0:b}}}}),f.attrHooks.tabindex=f.propHooks.tabIndex,x={get:function(a,c){var d,e=f.prop(a,c);return e===!0||typeof e!="boolean"&&(d=a.getAttributeNode(c))&&d.nodeValue!==!1?c.toLowerCase():b},set:function(a,b,c){var d;b===!1?f.removeAttr(a,c):(d=f.propFix[c]||c,d in a&&(a[d]=!0),a.setAttribute(c,c.toLowerCase()));return c}},v||(y={name:!0,id:!0},w=f.valHooks.button={get:function(a,c){var d;d=a.getAttributeNode(c);return d&&(y[c]?d.nodeValue!=="":d.specified)?d.nodeValue:b},set:function(a,b,d){var e=a.getAttributeNode(d);e||(e=c.createAttribute(d),a.setAttributeNode(e));return e.nodeValue=b+""}},f.attrHooks.tabindex.set=w.set,f.each(["width","height"],function(a,b){f.attrHooks[b]=f.extend(f.attrHooks[b],{set:function(a,c){if(c===""){a.setAttribute(b,"auto");return c}}})}),f.attrHooks.contenteditable={get:w.get,set:function(a,b,c){b===""&&(b="false"),w.set(a,b,c)}}),f.support.hrefNormalized||f.each(["href","src","width","height"],function(a,c){f.attrHooks[c]=f.extend(f.attrHooks[c],{get:function(a){var d=a.getAttribute(c,2);return d===null?b:d}})}),f.support.style||(f.attrHooks.style={get:function(a){return a.style.cssText.toLowerCase()||b},set:function(a,b){return a.style.cssText=""+b}}),f.support.optSelected||(f.propHooks.selected=f.extend(f.propHooks.selected,{get:function(a){var b=a.parentNode;b&&(b.selectedIndex,b.parentNode&&b.parentNode.selectedIndex);return null}})),f.support.enctype||(f.propFix.enctype="encoding"),f.support.checkOn||f.each(["radio","checkbox"],function(){f.valHooks[this]={get:function(a){return a.getAttribute("value")===null?"on":a.value}}}),f.each(["radio","checkbox"],function(){f.valHooks[this]=f.extend(f.valHooks[this],{set:function(a,b){if(f.isArray(b))return a.checked=f.inArray(f(a).val(),b)>=0}})});var z=/^(?:textarea|input|select)$/i,A=/^([^\.]*)?(?:\.(.+))?$/,B=/\bhover(\.\S+)?\b/,C=/^key/,D=/^(?:mouse|contextmenu)|click/,E=/^(?:focusinfocus|focusoutblur)$/,F=/^(\w*)(?:#([\w\-]+))?(?:\.([\w\-]+))?$/,G=function(a){var b=F.exec(a);b&&(b[1]=(b[1]||"").toLowerCase(),b[3]=b[3]&&new RegExp("(?:^|\\s)"+b[3]+"(?:\\s|$)"));return b},H=function(a,b){var c=a.attributes||{};return(!b[1]||a.nodeName.toLowerCase()===b[1])&&(!b[2]||(c.id||{}).value===b[2])&&(!b[3]||b[3].test((c["class"]||{}).value))},I=function(a){return f.event.special.hover?a:a.replace(B,"mouseenter$1 mouseleave$1")};
f.event={add:function(a,c,d,e,g){var h,i,j,k,l,m,n,o,p,q,r,s;if(!(a.nodeType===3||a.nodeType===8||!c||!d||!(h=f._data(a)))){d.handler&&(p=d,d=p.handler),d.guid||(d.guid=f.guid++),j=h.events,j||(h.events=j={}),i=h.handle,i||(h.handle=i=function(a){return typeof f!="undefined"&&(!a||f.event.triggered!==a.type)?f.event.dispatch.apply(i.elem,arguments):b},i.elem=a),c=f.trim(I(c)).split(" ");for(k=0;k<c.length;k++){l=A.exec(c[k])||[],m=l[1],n=(l[2]||"").split(".").sort(),s=f.event.special[m]||{},m=(g?s.delegateType:s.bindType)||m,s=f.event.special[m]||{},o=f.extend({type:m,origType:l[1],data:e,handler:d,guid:d.guid,selector:g,quick:G(g),namespace:n.join(".")},p),r=j[m];if(!r){r=j[m]=[],r.delegateCount=0;if(!s.setup||s.setup.call(a,e,n,i)===!1)a.addEventListener?a.addEventListener(m,i,!1):a.attachEvent&&a.attachEvent("on"+m,i)}s.add&&(s.add.call(a,o),o.handler.guid||(o.handler.guid=d.guid)),g?r.splice(r.delegateCount++,0,o):r.push(o),f.event.global[m]=!0}a=null}},global:{},remove:function(a,b,c,d,e){var g=f.hasData(a)&&f._data(a),h,i,j,k,l,m,n,o,p,q,r,s;if(!!g&&!!(o=g.events)){b=f.trim(I(b||"")).split(" ");for(h=0;h<b.length;h++){i=A.exec(b[h])||[],j=k=i[1],l=i[2];if(!j){for(j in o)f.event.remove(a,j+b[h],c,d,!0);continue}p=f.event.special[j]||{},j=(d?p.delegateType:p.bindType)||j,r=o[j]||[],m=r.length,l=l?new RegExp("(^|\\.)"+l.split(".").sort().join("\\.(?:.*\\.)?")+"(\\.|$)"):null;for(n=0;n<r.length;n++)s=r[n],(e||k===s.origType)&&(!c||c.guid===s.guid)&&(!l||l.test(s.namespace))&&(!d||d===s.selector||d==="**"&&s.selector)&&(r.splice(n--,1),s.selector&&r.delegateCount--,p.remove&&p.remove.call(a,s));r.length===0&&m!==r.length&&((!p.teardown||p.teardown.call(a,l)===!1)&&f.removeEvent(a,j,g.handle),delete o[j])}f.isEmptyObject(o)&&(q=g.handle,q&&(q.elem=null),f.removeData(a,["events","handle"],!0))}},customEvent:{getData:!0,setData:!0,changeData:!0},trigger:function(c,d,e,g){if(!e||e.nodeType!==3&&e.nodeType!==8){var h=c.type||c,i=[],j,k,l,m,n,o,p,q,r,s;if(E.test(h+f.event.triggered))return;h.indexOf("!")>=0&&(h=h.slice(0,-1),k=!0),h.indexOf(".")>=0&&(i=h.split("."),h=i.shift(),i.sort());if((!e||f.event.customEvent[h])&&!f.event.global[h])return;c=typeof c=="object"?c[f.expando]?c:new f.Event(h,c):new f.Event(h),c.type=h,c.isTrigger=!0,c.exclusive=k,c.namespace=i.join("."),c.namespace_re=c.namespace?new RegExp("(^|\\.)"+i.join("\\.(?:.*\\.)?")+"(\\.|$)"):null,o=h.indexOf(":")<0?"on"+h:"";if(!e){j=f.cache;for(l in j)j[l].events&&j[l].events[h]&&f.event.trigger(c,d,j[l].handle.elem,!0);return}c.result=b,c.target||(c.target=e),d=d!=null?f.makeArray(d):[],d.unshift(c),p=f.event.special[h]||{};if(p.trigger&&p.trigger.apply(e,d)===!1)return;r=[[e,p.bindType||h]];if(!g&&!p.noBubble&&!f.isWindow(e)){s=p.delegateType||h,m=E.test(s+h)?e:e.parentNode,n=null;for(;m;m=m.parentNode)r.push([m,s]),n=m;n&&n===e.ownerDocument&&r.push([n.defaultView||n.parentWindow||a,s])}for(l=0;l<r.length&&!c.isPropagationStopped();l++)m=r[l][0],c.type=r[l][1],q=(f._data(m,"events")||{})[c.type]&&f._data(m,"handle"),q&&q.apply(m,d),q=o&&m[o],q&&f.acceptData(m)&&q.apply(m,d)===!1&&c.preventDefault();c.type=h,!g&&!c.isDefaultPrevented()&&(!p._default||p._default.apply(e.ownerDocument,d)===!1)&&(h!=="click"||!f.nodeName(e,"a"))&&f.acceptData(e)&&o&&e[h]&&(h!=="focus"&&h!=="blur"||c.target.offsetWidth!==0)&&!f.isWindow(e)&&(n=e[o],n&&(e[o]=null),f.event.triggered=h,e[h](),f.event.triggered=b,n&&(e[o]=n));return c.result}},dispatch:function(c){c=f.event.fix(c||a.event);var d=(f._data(this,"events")||{})[c.type]||[],e=d.delegateCount,g=[].slice.call(arguments,0),h=!c.exclusive&&!c.namespace,i=[],j,k,l,m,n,o,p,q,r,s,t;g[0]=c,c.delegateTarget=this;if(e&&!c.target.disabled&&(!c.button||c.type!=="click")){m=f(this),m.context=this.ownerDocument||this;for(l=c.target;l!=this;l=l.parentNode||this){o={},q=[],m[0]=l;for(j=0;j<e;j++)r=d[j],s=r.selector,o[s]===b&&(o[s]=r.quick?H(l,r.quick):m.is(s)),o[s]&&q.push(r);q.length&&i.push({elem:l,matches:q})}}d.length>e&&i.push({elem:this,matches:d.slice(e)});for(j=0;j<i.length&&!c.isPropagationStopped();j++){p=i[j],c.currentTarget=p.elem;for(k=0;k<p.matches.length&&!c.isImmediatePropagationStopped();k++){r=p.matches[k];if(h||!c.namespace&&!r.namespace||c.namespace_re&&c.namespace_re.test(r.namespace))c.data=r.data,c.handleObj=r,n=((f.event.special[r.origType]||{}).handle||r.handler).apply(p.elem,g),n!==b&&(c.result=n,n===!1&&(c.preventDefault(),c.stopPropagation()))}}return c.result},props:"attrChange attrName relatedNode srcElement altKey bubbles cancelable ctrlKey currentTarget eventPhase metaKey relatedTarget shiftKey target timeStamp view which".split(" "),fixHooks:{},keyHooks:{props:"char charCode key keyCode".split(" "),filter:function(a,b){a.which==null&&(a.which=b.charCode!=null?b.charCode:b.keyCode);return a}},mouseHooks:{props:"button buttons clientX clientY fromElement offsetX offsetY pageX pageY screenX screenY toElement".split(" "),filter:function(a,d){var e,f,g,h=d.button,i=d.fromElement;a.pageX==null&&d.clientX!=null&&(e=a.target.ownerDocument||c,f=e.documentElement,g=e.body,a.pageX=d.clientX+(f&&f.scrollLeft||g&&g.scrollLeft||0)-(f&&f.clientLeft||g&&g.clientLeft||0),a.pageY=d.clientY+(f&&f.scrollTop||g&&g.scrollTop||0)-(f&&f.clientTop||g&&g.clientTop||0)),!a.relatedTarget&&i&&(a.relatedTarget=i===a.target?d.toElement:i),!a.which&&h!==b&&(a.which=h&1?1:h&2?3:h&4?2:0);return a}},fix:function(a){if(a[f.expando])return a;var d,e,g=a,h=f.event.fixHooks[a.type]||{},i=h.props?this.props.concat(h.props):this.props;a=f.Event(g);for(d=i.length;d;)e=i[--d],a[e]=g[e];a.target||(a.target=g.srcElement||c),a.target.nodeType===3&&(a.target=a.target.parentNode),a.metaKey===b&&(a.metaKey=a.ctrlKey);return h.filter?h.filter(a,g):a},special:{ready:{setup:f.bindReady},load:{noBubble:!0},focus:{delegateType:"focusin"},blur:{delegateType:"focusout"},beforeunload:{setup:function(a,b,c){f.isWindow(this)&&(this.onbeforeunload=c)},teardown:function(a,b){this.onbeforeunload===b&&(this.onbeforeunload=null)}}},simulate:function(a,b,c,d){var e=f.extend(new f.Event,c,{type:a,isSimulated:!0,originalEvent:{}});d?f.event.trigger(e,null,b):f.event.dispatch.call(b,e),e.isDefaultPrevented()&&c.preventDefault()}},f.event.handle=f.event.dispatch,f.removeEvent=c.removeEventListener?function(a,b,c){a.removeEventListener&&a.removeEventListener(b,c,!1)}:function(a,b,c){a.detachEvent&&a.detachEvent("on"+b,c)},f.Event=function(a,b){if(!(this instanceof f.Event))return new f.Event(a,b);a&&a.type?(this.originalEvent=a,this.type=a.type,this.isDefaultPrevented=a.defaultPrevented||a.returnValue===!1||a.getPreventDefault&&a.getPreventDefault()?K:J):this.type=a,b&&f.extend(this,b),this.timeStamp=a&&a.timeStamp||f.now(),this[f.expando]=!0},f.Event.prototype={preventDefault:function(){this.isDefaultPrevented=K;var a=this.originalEvent;!a||(a.preventDefault?a.preventDefault():a.returnValue=!1)},stopPropagation:function(){this.isPropagationStopped=K;var a=this.originalEvent;!a||(a.stopPropagation&&a.stopPropagation(),a.cancelBubble=!0)},stopImmediatePropagation:function(){this.isImmediatePropagationStopped=K,this.stopPropagation()},isDefaultPrevented:J,isPropagationStopped:J,isImmediatePropagationStopped:J},f.each({mouseenter:"mouseover",mouseleave:"mouseout"},function(a,b){f.event.special[a]={delegateType:b,bindType:b,handle:function(a){var c=this,d=a.relatedTarget,e=a.handleObj,g=e.selector,h;if(!d||d!==c&&!f.contains(c,d))a.type=e.origType,h=e.handler.apply(this,arguments),a.type=b;return h}}}),f.support.submitBubbles||(f.event.special.submit={setup:function(){if(f.nodeName(this,"form"))return!1;f.event.add(this,"click._submit keypress._submit",function(a){var c=a.target,d=f.nodeName(c,"input")||f.nodeName(c,"button")?c.form:b;d&&!d._submit_attached&&(f.event.add(d,"submit._submit",function(a){this.parentNode&&!a.isTrigger&&f.event.simulate("submit",this.parentNode,a,!0)}),d._submit_attached=!0)})},teardown:function(){if(f.nodeName(this,"form"))return!1;f.event.remove(this,"._submit")}}),f.support.changeBubbles||(f.event.special.change={setup:function(){if(z.test(this.nodeName)){if(this.type==="checkbox"||this.type==="radio")f.event.add(this,"propertychange._change",function(a){a.originalEvent.propertyName==="checked"&&(this._just_changed=!0)}),f.event.add(this,"click._change",function(a){this._just_changed&&!a.isTrigger&&(this._just_changed=!1,f.event.simulate("change",this,a,!0))});return!1}f.event.add(this,"beforeactivate._change",function(a){var b=a.target;z.test(b.nodeName)&&!b._change_attached&&(f.event.add(b,"change._change",function(a){this.parentNode&&!a.isSimulated&&!a.isTrigger&&f.event.simulate("change",this.parentNode,a,!0)}),b._change_attached=!0)})},handle:function(a){var b=a.target;if(this!==b||a.isSimulated||a.isTrigger||b.type!=="radio"&&b.type!=="checkbox")return a.handleObj.handler.apply(this,arguments)},teardown:function(){f.event.remove(this,"._change");return z.test(this.nodeName)}}),f.support.focusinBubbles||f.each({focus:"focusin",blur:"focusout"},function(a,b){var d=0,e=function(a){f.event.simulate(b,a.target,f.event.fix(a),!0)};f.event.special[b]={setup:function(){d++===0&&c.addEventListener(a,e,!0)},teardown:function(){--d===0&&c.removeEventListener(a,e,!0)}}}),f.fn.extend({on:function(a,c,d,e,g){var h,i;if(typeof a=="object"){typeof c!="string"&&(d=c,c=b);for(i in a)this.on(i,c,d,a[i],g);return this}d==null&&e==null?(e=c,d=c=b):e==null&&(typeof c=="string"?(e=d,d=b):(e=d,d=c,c=b));if(e===!1)e=J;else if(!e)return this;g===1&&(h=e,e=function(a){f().off(a);return h.apply(this,arguments)},e.guid=h.guid||(h.guid=f.guid++));return this.each(function(){f.event.add(this,a,e,d,c)})},one:function(a,b,c,d){return this.on.call(this,a,b,c,d,1)},off:function(a,c,d){if(a&&a.preventDefault&&a.handleObj){var e=a.handleObj;f(a.delegateTarget).off(e.namespace?e.type+"."+e.namespace:e.type,e.selector,e.handler);return this}if(typeof a=="object"){for(var g in a)this.off(g,c,a[g]);return this}if(c===!1||typeof c=="function")d=c,c=b;d===!1&&(d=J);return this.each(function(){f.event.remove(this,a,d,c)})},bind:function(a,b,c){return this.on(a,null,b,c)},unbind:function(a,b){return this.off(a,null,b)},live:function(a,b,c){f(this.context).on(a,this.selector,b,c);return this},die:function(a,b){f(this.context).off(a,this.selector||"**",b);return this},delegate:function(a,b,c,d){return this.on(b,a,c,d)},undelegate:function(a,b,c){return arguments.length==1?this.off(a,"**"):this.off(b,a,c)},trigger:function(a,b){return this.each(function(){f.event.trigger(a,b,this)})},triggerHandler:function(a,b){if(this[0])return f.event.trigger(a,b,this[0],!0)},toggle:function(a){var b=arguments,c=a.guid||f.guid++,d=0,e=function(c){var e=(f._data(this,"lastToggle"+a.guid)||0)%d;f._data(this,"lastToggle"+a.guid,e+1),c.preventDefault();return b[e].apply(this,arguments)||!1};e.guid=c;while(d<b.length)b[d++].guid=c;return this.click(e)},hover:function(a,b){return this.mouseenter(a).mouseleave(b||a)}}),f.each("blur focus focusin focusout load resize scroll unload click dblclick mousedown mouseup mousemove mouseover mouseout mouseenter mouseleave change select submit keydown keypress keyup error contextmenu".split(" "),function(a,b){f.fn[b]=function(a,c){c==null&&(c=a,a=null);return arguments.length>0?this.on(b,null,a,c):this.trigger(b)},f.attrFn&&(f.attrFn[b]=!0),C.test(b)&&(f.event.fixHooks[b]=f.event.keyHooks),D.test(b)&&(f.event.fixHooks[b]=f.event.mouseHooks)}),function(){function x(a,b,c,e,f,g){for(var h=0,i=e.length;h<i;h++){var j=e[h];if(j){var k=!1;j=j[a];while(j){if(j[d]===c){k=e[j.sizset];break}if(j.nodeType===1){g||(j[d]=c,j.sizset=h);if(typeof b!="string"){if(j===b){k=!0;break}}else if(m.filter(b,[j]).length>0){k=j;break}}j=j[a]}e[h]=k}}}function w(a,b,c,e,f,g){for(var h=0,i=e.length;h<i;h++){var j=e[h];if(j){var k=!1;j=j[a];while(j){if(j[d]===c){k=e[j.sizset];break}j.nodeType===1&&!g&&(j[d]=c,j.sizset=h);if(j.nodeName.toLowerCase()===b){k=j;break}j=j[a]}e[h]=k}}}var a=/((?:\((?:\([^()]+\)|[^()]+)+\)|\[(?:\[[^\[\]]*\]|['"][^'"]*['"]|[^\[\]'"]+)+\]|\\.|[^ >+~,(\[\\]+)+|[>+~])(\s*,\s*)?((?:.|\r|\n)*)/g,d="sizcache"+(Math.random()+"").replace(".",""),e=0,g=Object.prototype.toString,h=!1,i=!0,j=/\\/g,k=/\r\n/g,l=/\W/;[0,0].sort(function(){i=!1;return 0});var m=function(b,d,e,f){e=e||[],d=d||c;var h=d;if(d.nodeType!==1&&d.nodeType!==9)return[];if(!b||typeof b!="string")return e;var i,j,k,l,n,q,r,t,u=!0,v=m.isXML(d),w=[],x=b;do{a.exec(""),i=a.exec(x);if(i){x=i[3],w.push(i[1]);if(i[2]){l=i[3];break}}}while(i);if(w.length>1&&p.exec(b))if(w.length===2&&o.relative[w[0]])j=y(w[0]+w[1],d,f);else{j=o.relative[w[0]]?[d]:m(w.shift(),d);while(w.length)b=w.shift(),o.relative[b]&&(b+=w.shift()),j=y(b,j,f)}else{!f&&w.length>1&&d.nodeType===9&&!v&&o.match.ID.test(w[0])&&!o.match.ID.test(w[w.length-1])&&(n=m.find(w.shift(),d,v),d=n.expr?m.filter(n.expr,n.set)[0]:n.set[0]);if(d){n=f?{expr:w.pop(),set:s(f)}:m.find(w.pop(),w.length===1&&(w[0]==="~"||w[0]==="+")&&d.parentNode?d.parentNode:d,v),j=n.expr?m.filter(n.expr,n.set):n.set,w.length>0?k=s(j):u=!1;while(w.length)q=w.pop(),r=q,o.relative[q]?r=w.pop():q="",r==null&&(r=d),o.relative[q](k,r,v)}else k=w=[]}k||(k=j),k||m.error(q||b);if(g.call(k)==="[object Array]")if(!u)e.push.apply(e,k);else if(d&&d.nodeType===1)for(t=0;k[t]!=null;t++)k[t]&&(k[t]===!0||k[t].nodeType===1&&m.contains(d,k[t]))&&e.push(j[t]);else for(t=0;k[t]!=null;t++)k[t]&&k[t].nodeType===1&&e.push(j[t]);else s(k,e);l&&(m(l,h,e,f),m.uniqueSort(e));return e};m.uniqueSort=function(a){if(u){h=i,a.sort(u);if(h)for(var b=1;b<a.length;b++)a[b]===a[b-1]&&a.splice(b--,1)}return a},m.matches=function(a,b){return m(a,null,null,b)},m.matchesSelector=function(a,b){return m(b,null,null,[a]).length>0},m.find=function(a,b,c){var d,e,f,g,h,i;if(!a)return[];for(e=0,f=o.order.length;e<f;e++){h=o.order[e];if(g=o.leftMatch[h].exec(a)){i=g[1],g.splice(1,1);if(i.substr(i.length-1)!=="\\"){g[1]=(g[1]||"").replace(j,""),d=o.find[h](g,b,c);if(d!=null){a=a.replace(o.match[h],"");break}}}}d||(d=typeof b.getElementsByTagName!="undefined"?b.getElementsByTagName("*"):[]);return{set:d,expr:a}},m.filter=function(a,c,d,e){var f,g,h,i,j,k,l,n,p,q=a,r=[],s=c,t=c&&c[0]&&m.isXML(c[0]);while(a&&c.length){for(h in o.filter)if((f=o.leftMatch[h].exec(a))!=null&&f[2]){k=o.filter[h],l=f[1],g=!1,f.splice(1,1);if(l.substr(l.length-1)==="\\")continue;s===r&&(r=[]);if(o.preFilter[h]){f=o.preFilter[h](f,s,d,r,e,t);if(!f)g=i=!0;else if(f===!0)continue}if(f)for(n=0;(j=s[n])!=null;n++)j&&(i=k(j,f,n,s),p=e^i,d&&i!=null?p?g=!0:s[n]=!1:p&&(r.push(j),g=!0));if(i!==b){d||(s=r),a=a.replace(o.match[h],"");if(!g)return[];break}}if(a===q)if(g==null)m.error(a);else break;q=a}return s},m.error=function(a){throw new Error("Syntax error, unrecognized expression: "+a)};var n=m.getText=function(a){var b,c,d=a.nodeType,e="";if(d){if(d===1||d===9){if(typeof a.textContent=="string")return a.textContent;if(typeof a.innerText=="string")return a.innerText.replace(k,"");for(a=a.firstChild;a;a=a.nextSibling)e+=n(a)}else if(d===3||d===4)return a.nodeValue}else for(b=0;c=a[b];b++)c.nodeType!==8&&(e+=n(c));return e},o=m.selectors={order:["ID","NAME","TAG"],match:{ID:/#((?:[\w\u00c0-\uFFFF\-]|\\.)+)/,CLASS:/\.((?:[\w\u00c0-\uFFFF\-]|\\.)+)/,NAME:/\[name=['"]*((?:[\w\u00c0-\uFFFF\-]|\\.)+)['"]*\]/,ATTR:/\[\s*((?:[\w\u00c0-\uFFFF\-]|\\.)+)\s*(?:(\S?=)\s*(?:(['"])(.*?)\3|(#?(?:[\w\u00c0-\uFFFF\-]|\\.)*)|)|)\s*\]/,TAG:/^((?:[\w\u00c0-\uFFFF\*\-]|\\.)+)/,CHILD:/:(only|nth|last|first)-child(?:\(\s*(even|odd|(?:[+\-]?\d+|(?:[+\-]?\d*)?n\s*(?:[+\-]\s*\d+)?))\s*\))?/,POS:/:(nth|eq|gt|lt|first|last|even|odd)(?:\((\d*)\))?(?=[^\-]|$)/,PSEUDO:/:((?:[\w\u00c0-\uFFFF\-]|\\.)+)(?:\((['"]?)((?:\([^\)]+\)|[^\(\)]*)+)\2\))?/},leftMatch:{},attrMap:{"class":"className","for":"htmlFor"},attrHandle:{href:function(a){return a.getAttribute("href")},type:function(a){return a.getAttribute("type")}},relative:{"+":function(a,b){var c=typeof b=="string",d=c&&!l.test(b),e=c&&!d;d&&(b=b.toLowerCase());for(var f=0,g=a.length,h;f<g;f++)if(h=a[f]){while((h=h.previousSibling)&&h.nodeType!==1);a[f]=e||h&&h.nodeName.toLowerCase()===b?h||!1:h===b}e&&m.filter(b,a,!0)},">":function(a,b){var c,d=typeof b=="string",e=0,f=a.length;if(d&&!l.test(b)){b=b.toLowerCase();for(;e<f;e++){c=a[e];if(c){var g=c.parentNode;a[e]=g.nodeName.toLowerCase()===b?g:!1}}}else{for(;e<f;e++)c=a[e],c&&(a[e]=d?c.parentNode:c.parentNode===b);d&&m.filter(b,a,!0)}},"":function(a,b,c){var d,f=e++,g=x;typeof b=="string"&&!l.test(b)&&(b=b.toLowerCase(),d=b,g=w),g("parentNode",b,f,a,d,c)},"~":function(a,b,c){var d,f=e++,g=x;typeof b=="string"&&!l.test(b)&&(b=b.toLowerCase(),d=b,g=w),g("previousSibling",b,f,a,d,c)}},find:{ID:function(a,b,c){if(typeof b.getElementById!="undefined"&&!c){var d=b.getElementById(a[1]);return d&&d.parentNode?[d]:[]}},NAME:function(a,b){if(typeof b.getElementsByName!="undefined"){var c=[],d=b.getElementsByName(a[1]);for(var e=0,f=d.length;e<f;e++)d[e].getAttribute("name")===a[1]&&c.push(d[e]);return c.length===0?null:c}},TAG:function(a,b){if(typeof b.getElementsByTagName!="undefined")return b.getElementsByTagName(a[1])}},preFilter:{CLASS:function(a,b,c,d,e,f){a=" "+a[1].replace(j,"")+" ";if(f)return a;for(var g=0,h;(h=b[g])!=null;g++)h&&(e^(h.className&&(" "+h.className+" ").replace(/[\t\n\r]/g," ").indexOf(a)>=0)?c||d.push(h):c&&(b[g]=!1));return!1},ID:function(a){return a[1].replace(j,"")},TAG:function(a,b){return a[1].replace(j,"").toLowerCase()},CHILD:function(a){if(a[1]==="nth"){a[2]||m.error(a[0]),a[2]=a[2].replace(/^\+|\s*/g,"");var b=/(-?)(\d*)(?:n([+\-]?\d*))?/.exec(a[2]==="even"&&"2n"||a[2]==="odd"&&"2n+1"||!/\D/.test(a[2])&&"0n+"+a[2]||a[2]);a[2]=b[1]+(b[2]||1)-0,a[3]=b[3]-0}else a[2]&&m.error(a[0]);a[0]=e++;return a},ATTR:function(a,b,c,d,e,f){var g=a[1]=a[1].replace(j,"");!f&&o.attrMap[g]&&(a[1]=o.attrMap[g]),a[4]=(a[4]||a[5]||"").replace(j,""),a[2]==="~="&&(a[4]=" "+a[4]+" ");return a},PSEUDO:function(b,c,d,e,f){if(b[1]==="not")if((a.exec(b[3])||"").length>1||/^\w/.test(b[3]))b[3]=m(b[3],null,null,c);else{var g=m.filter(b[3],c,d,!0^f);d||e.push.apply(e,g);return!1}else if(o.match.POS.test(b[0])||o.match.CHILD.test(b[0]))return!0;return b},POS:function(a){a.unshift(!0);return a}},filters:{enabled:function(a){return a.disabled===!1&&a.type!=="hidden"},disabled:function(a){return a.disabled===!0},checked:function(a){return a.checked===!0},selected:function(a){a.parentNode&&a.parentNode.selectedIndex;return a.selected===!0},parent:function(a){return!!a.firstChild},empty:function(a){return!a.firstChild},has:function(a,b,c){return!!m(c[3],a).length},header:function(a){return/h\d/i.test(a.nodeName)},text:function(a){var b=a.getAttribute("type"),c=a.type;return a.nodeName.toLowerCase()==="input"&&"text"===c&&(b===c||b===null)},radio:function(a){return a.nodeName.toLowerCase()==="input"&&"radio"===a.type},checkbox:function(a){return a.nodeName.toLowerCase()==="input"&&"checkbox"===a.type},file:function(a){return a.nodeName.toLowerCase()==="input"&&"file"===a.type},password:function(a){return a.nodeName.toLowerCase()==="input"&&"password"===a.type},submit:function(a){var b=a.nodeName.toLowerCase();return(b==="input"||b==="button")&&"submit"===a.type},image:function(a){return a.nodeName.toLowerCase()==="input"&&"image"===a.type},reset:function(a){var b=a.nodeName.toLowerCase();return(b==="input"||b==="button")&&"reset"===a.type},button:function(a){var b=a.nodeName.toLowerCase();return b==="input"&&"button"===a.type||b==="button"},input:function(a){return/input|select|textarea|button/i.test(a.nodeName)},focus:function(a){return a===a.ownerDocument.activeElement}},setFilters:{first:function(a,b){return b===0},last:function(a,b,c,d){return b===d.length-1},even:function(a,b){return b%2===0},odd:function(a,b){return b%2===1},lt:function(a,b,c){return b<c[3]-0},gt:function(a,b,c){return b>c[3]-0},nth:function(a,b,c){return c[3]-0===b},eq:function(a,b,c){return c[3]-0===b}},filter:{PSEUDO:function(a,b,c,d){var e=b[1],f=o.filters[e];if(f)return f(a,c,b,d);if(e==="contains")return(a.textContent||a.innerText||n([a])||"").indexOf(b[3])>=0;if(e==="not"){var g=b[3];for(var h=0,i=g.length;h<i;h++)if(g[h]===a)return!1;return!0}m.error(e)},CHILD:function(a,b){var c,e,f,g,h,i,j,k=b[1],l=a;switch(k){case"only":case"first":while(l=l.previousSibling)if(l.nodeType===1)return!1;if(k==="first")return!0;l=a;case"last":while(l=l.nextSibling)if(l.nodeType===1)return!1;return!0;case"nth":c=b[2],e=b[3];if(c===1&&e===0)return!0;f=b[0],g=a.parentNode;if(g&&(g[d]!==f||!a.nodeIndex)){i=0;for(l=g.firstChild;l;l=l.nextSibling)l.nodeType===1&&(l.nodeIndex=++i);g[d]=f}j=a.nodeIndex-e;return c===0?j===0:j%c===0&&j/c>=0}},ID:function(a,b){return a.nodeType===1&&a.getAttribute("id")===b},TAG:function(a,b){return b==="*"&&a.nodeType===1||!!a.nodeName&&a.nodeName.toLowerCase()===b},CLASS:function(a,b){return(" "+(a.className||a.getAttribute("class"))+" ").indexOf(b)>-1},ATTR:function(a,b){var c=b[1],d=m.attr?m.attr(a,c):o.attrHandle[c]?o.attrHandle[c](a):a[c]!=null?a[c]:a.getAttribute(c),e=d+"",f=b[2],g=b[4];return d==null?f==="!=":!f&&m.attr?d!=null:f==="="?e===g:f==="*="?e.indexOf(g)>=0:f==="~="?(" "+e+" ").indexOf(g)>=0:g?f==="!="?e!==g:f==="^="?e.indexOf(g)===0:f==="$="?e.substr(e.length-g.length)===g:f==="|="?e===g||e.substr(0,g.length+1)===g+"-":!1:e&&d!==!1},POS:function(a,b,c,d){var e=b[2],f=o.setFilters[e];if(f)return f(a,c,b,d)}}},p=o.match.POS,q=function(a,b){return"\\"+(b-0+1)};for(var r in o.match)o.match[r]=new RegExp(o.match[r].source+/(?![^\[]*\])(?![^\(]*\))/.source),o.leftMatch[r]=new RegExp(/(^(?:.|\r|\n)*?)/.source+o.match[r].source.replace(/\\(\d+)/g,q));var s=function(a,b){a=Array.prototype.slice.call(a,0);if(b){b.push.apply(b,a);return b}return a};try{Array.prototype.slice.call(c.documentElement.childNodes,0)[0].nodeType}catch(t){s=function(a,b){var c=0,d=b||[];if(g.call(a)==="[object Array]")Array.prototype.push.apply(d,a);else if(typeof a.length=="number")for(var e=a.length;c<e;c++)d.push(a[c]);else for(;a[c];c++)d.push(a[c]);return d}}var u,v;c.documentElement.compareDocumentPosition?u=function(a,b){if(a===b){h=!0;return 0}if(!a.compareDocumentPosition||!b.compareDocumentPosition)return a.compareDocumentPosition?-1:1;return a.compareDocumentPosition(b)&4?-1:1}:(u=function(a,b){if(a===b){h=!0;return 0}if(a.sourceIndex&&b.sourceIndex)return a.sourceIndex-b.sourceIndex;var c,d,e=[],f=[],g=a.parentNode,i=b.parentNode,j=g;if(g===i)return v(a,b);if(!g)return-1;if(!i)return 1;while(j)e.unshift(j),j=j.parentNode;j=i;while(j)f.unshift(j),j=j.parentNode;c=e.length,d=f.length;for(var k=0;k<c&&k<d;k++)if(e[k]!==f[k])return v(e[k],f[k]);return k===c?v(a,f[k],-1):v(e[k],b,1)},v=function(a,b,c){if(a===b)return c;var d=a.nextSibling;while(d){if(d===b)return-1;d=d.nextSibling}return 1}),function(){var a=c.createElement("div"),d="script"+(new Date).getTime(),e=c.documentElement;a.innerHTML="<a name='"+d+"'/>",e.insertBefore(a,e.firstChild),c.getElementById(d)&&(o.find.ID=function(a,c,d){if(typeof c.getElementById!="undefined"&&!d){var e=c.getElementById(a[1]);return e?e.id===a[1]||typeof e.getAttributeNode!="undefined"&&e.getAttributeNode("id").nodeValue===a[1]?[e]:b:[]}},o.filter.ID=function(a,b){var c=typeof a.getAttributeNode!="undefined"&&a.getAttributeNode("id");return a.nodeType===1&&c&&c.nodeValue===b}),e.removeChild(a),e=a=null}(),function(){var a=c.createElement("div");a.appendChild(c.createComment("")),a.getElementsByTagName("*").length>0&&(o.find.TAG=function(a,b){var c=b.getElementsByTagName(a[1]);if(a[1]==="*"){var d=[];for(var e=0;c[e];e++)c[e].nodeType===1&&d.push(c[e]);c=d}return c}),a.innerHTML="<a href='#'></a>",a.firstChild&&typeof a.firstChild.getAttribute!="undefined"&&a.firstChild.getAttribute("href")!=="#"&&(o.attrHandle.href=function(a){return a.getAttribute("href",2)}),a=null}(),c.querySelectorAll&&function(){var a=m,b=c.createElement("div"),d="__sizzle__";b.innerHTML="<p class='TEST'></p>";if(!b.querySelectorAll||b.querySelectorAll(".TEST").length!==0){m=function(b,e,f,g){e=e||c;if(!g&&!m.isXML(e)){var h=/^(\w+$)|^\.([\w\-]+$)|^#([\w\-]+$)/.exec(b);if(h&&(e.nodeType===1||e.nodeType===9)){if(h[1])return s(e.getElementsByTagName(b),f);if(h[2]&&o.find.CLASS&&e.getElementsByClassName)return s(e.getElementsByClassName(h[2]),f)}if(e.nodeType===9){if(b==="body"&&e.body)return s([e.body],f);if(h&&h[3]){var i=e.getElementById(h[3]);if(!i||!i.parentNode)return s([],f);if(i.id===h[3])return s([i],f)}try{return s(e.querySelectorAll(b),f)}catch(j){}}else if(e.nodeType===1&&e.nodeName.toLowerCase()!=="object"){var k=e,l=e.getAttribute("id"),n=l||d,p=e.parentNode,q=/^\s*[+~]/.test(b);l?n=n.replace(/'/g,"\\$&"):e.setAttribute("id",n),q&&p&&(e=e.parentNode);try{if(!q||p)return s(e.querySelectorAll("[id='"+n+"'] "+b),f)}catch(r){}finally{l||k.removeAttribute("id")}}}return a(b,e,f,g)};for(var e in a)m[e]=a[e];b=null}}(),function(){var a=c.documentElement,b=a.matchesSelector||a.mozMatchesSelector||a.webkitMatchesSelector||a.msMatchesSelector;if(b){var d=!b.call(c.createElement("div"),"div"),e=!1;try{b.call(c.documentElement,"[test!='']:sizzle")}catch(f){e=!0}m.matchesSelector=function(a,c){c=c.replace(/\=\s*([^'"\]]*)\s*\]/g,"='$1']");if(!m.isXML(a))try{if(e||!o.match.PSEUDO.test(c)&&!/!=/.test(c)){var f=b.call(a,c);if(f||!d||a.document&&a.document.nodeType!==11)return f}}catch(g){}return m(c,null,null,[a]).length>0}}}(),function(){var a=c.createElement("div");a.innerHTML="<div class='test e'></div><div class='test'></div>";if(!!a.getElementsByClassName&&a.getElementsByClassName("e").length!==0){a.lastChild.className="e";if(a.getElementsByClassName("e").length===1)return;o.order.splice(1,0,"CLASS"),o.find.CLASS=function(a,b,c){if(typeof b.getElementsByClassName!="undefined"&&!c)return b.getElementsByClassName(a[1])},a=null}}(),c.documentElement.contains?m.contains=function(a,b){return a!==b&&(a.contains?a.contains(b):!0)}:c.documentElement.compareDocumentPosition?m.contains=function(a,b){return!!(a.compareDocumentPosition(b)&16)}:m.contains=function(){return!1},m.isXML=function(a){var b=(a?a.ownerDocument||a:0).documentElement;return b?b.nodeName!=="HTML":!1};var y=function(a,b,c){var d,e=[],f="",g=b.nodeType?[b]:b;while(d=o.match.PSEUDO.exec(a))f+=d[0],a=a.replace(o.match.PSEUDO,"");a=o.relative[a]?a+"*":a;for(var h=0,i=g.length;h<i;h++)m(a,g[h],e,c);return m.filter(f,e)};m.attr=f.attr,m.selectors.attrMap={},f.find=m,f.expr=m.selectors,f.expr[":"]=f.expr.filters,f.unique=m.uniqueSort,f.text=m.getText,f.isXMLDoc=m.isXML,f.contains=m.contains}();var L=/Until$/,M=/^(?:parents|prevUntil|prevAll)/,N=/,/,O=/^.[^:#\[\.,]*$/,P=Array.prototype.slice,Q=f.expr.match.POS,R={children:!0,contents:!0,next:!0,prev:!0};f.fn.extend({find:function(a){var b=this,c,d;if(typeof a!="string")return f(a).filter(function(){for(c=0,d=b.length;c<d;c++)if(f.contains(b[c],this))return!0});var e=this.pushStack("","find",a),g,h,i;for(c=0,d=this.length;c<d;c++){g=e.length,f.find(a,this[c],e);if(c>0)for(h=g;h<e.length;h++)for(i=0;i<g;i++)if(e[i]===e[h]){e.splice(h--,1);break}}return e},has:function(a){var b=f(a);return this.filter(function(){for(var a=0,c=b.length;a<c;a++)if(f.contains(this,b[a]))return!0})},not:function(a){return this.pushStack(T(this,a,!1),"not",a)},filter:function(a){return this.pushStack(T(this,a,!0),"filter",a)},is:function(a){return!!a&&(typeof a=="string"?Q.test(a)?f(a,this.context).index(this[0])>=0:f.filter(a,this).length>0:this.filter(a).length>0)},closest:function(a,b){var c=[],d,e,g=this[0];if(f.isArray(a)){var h=1;while(g&&g.ownerDocument&&g!==b){for(d=0;d<a.length;d++)f(g).is(a[d])&&c.push({selector:a[d],elem:g,level:h});g=g.parentNode,h++}return c}var i=Q.test(a)||typeof a!="string"?f(a,b||this.context):0;for(d=0,e=this.length;d<e;d++){g=this[d];while(g){if(i?i.index(g)>-1:f.find.matchesSelector(g,a)){c.push(g);break}g=g.parentNode;if(!g||!g.ownerDocument||g===b||g.nodeType===11)break}}c=c.length>1?f.unique(c):c;return this.pushStack(c,"closest",a)},index:function(a){if(!a)return this[0]&&this[0].parentNode?this.prevAll().length:-1;if(typeof a=="string")return f.inArray(this[0],f(a));return f.inArray(a.jquery?a[0]:a,this)},add:function(a,b){var c=typeof a=="string"?f(a,b):f.makeArray(a&&a.nodeType?[a]:a),d=f.merge(this.get(),c);return this.pushStack(S(c[0])||S(d[0])?d:f.unique(d))},andSelf:function(){return this.add(this.prevObject)}}),f.each({parent:function(a){var b=a.parentNode;return b&&b.nodeType!==11?b:null},parents:function(a){return f.dir(a,"parentNode")},parentsUntil:function(a,b,c){return f.dir(a,"parentNode",c)},next:function(a){return f.nth(a,2,"nextSibling")},prev:function(a){return f.nth(a,2,"previousSibling")},nextAll:function(a){return f.dir(a,"nextSibling")},prevAll:function(a){return f.dir(a,"previousSibling")},nextUntil:function(a,b,c){return f.dir(a,"nextSibling",c)},prevUntil:function(a,b,c){return f.dir(a,"previousSibling",c)},siblings:function(a){return f.sibling(a.parentNode.firstChild,a)},children:function(a){return f.sibling(a.firstChild)},contents:function(a){return f.nodeName(a,"iframe")?a.contentDocument||a.contentWindow.document:f.makeArray(a.childNodes)}},function(a,b){f.fn[a]=function(c,d){var e=f.map(this,b,c);L.test(a)||(d=c),d&&typeof d=="string"&&(e=f.filter(d,e)),e=this.length>1&&!R[a]?f.unique(e):e,(this.length>1||N.test(d))&&M.test(a)&&(e=e.reverse());return this.pushStack(e,a,P.call(arguments).join(","))}}),f.extend({filter:function(a,b,c){c&&(a=":not("+a+")");return b.length===1?f.find.matchesSelector(b[0],a)?[b[0]]:[]:f.find.matches(a,b)},dir:function(a,c,d){var e=[],g=a[c];while(g&&g.nodeType!==9&&(d===b||g.nodeType!==1||!f(g).is(d)))g.nodeType===1&&e.push(g),g=g[c];return e},nth:function(a,b,c,d){b=b||1;var e=0;for(;a;a=a[c])if(a.nodeType===1&&++e===b)break;return a},sibling:function(a,b){var c=[];for(;a;a=a.nextSibling)a.nodeType===1&&a!==b&&c.push(a);return c}});var V="abbr|article|aside|audio|canvas|datalist|details|figcaption|figure|footer|header|hgroup|mark|meter|nav|output|progress|section|summary|time|video",W=/ jQuery\d+="(?:\d+|null)"/g,X=/^\s+/,Y=/<(?!area|br|col|embed|hr|img|input|link|meta|param)(([\w:]+)[^>]*)\/>/ig,Z=/<([\w:]+)/,$=/<tbody/i,_=/<|&#?\w+;/,ba=/<(?:script|style)/i,bb=/<(?:script|object|embed|option|style)/i,bc=new RegExp("<(?:"+V+")","i"),bd=/checked\s*(?:[^=]|=\s*.checked.)/i,be=/\/(java|ecma)script/i,bf=/^\s*<!(?:\[CDATA\[|\-\-)/,bg={option:[1,"<select multiple='multiple'>","</select>"],legend:[1,"<fieldset>","</fieldset>"],thead:[1,"<table>","</table>"],tr:[2,"<table><tbody>","</tbody></table>"],td:[3,"<table><tbody><tr>","</tr></tbody></table>"],col:[2,"<table><tbody></tbody><colgroup>","</colgroup></table>"],area:[1,"<map>","</map>"],_default:[0,"",""]},bh=U(c);bg.optgroup=bg.option,bg.tbody=bg.tfoot=bg.colgroup=bg.caption=bg.thead,bg.th=bg.td,f.support.htmlSerialize||(bg._default=[1,"div<div>","</div>"]),f.fn.extend({text:function(a){if(f.isFunction(a))return this.each(function(b){var c=f(this);c.text(a.call(this,b,c.text()))});if(typeof a!="object"&&a!==b)return this.empty().append((this[0]&&this[0].ownerDocument||c).createTextNode(a));return f.text(this)},wrapAll:function(a){if(f.isFunction(a))return this.each(function(b){f(this).wrapAll(a.call(this,b))});if(this[0]){var b=f(a,this[0].ownerDocument).eq(0).clone(!0);this[0].parentNode&&b.insertBefore(this[0]),b.map(function(){var a=this;while(a.firstChild&&a.firstChild.nodeType===1)a=a.firstChild;return a}).append(this)}return this},wrapInner:function(a){if(f.isFunction(a))return this.each(function(b){f(this).wrapInner(a.call(this,b))});return this.each(function(){var b=f(this),c=b.contents();c.length?c.wrapAll(a):b.append(a)})},wrap:function(a){var b=f.isFunction(a);return this.each(function(c){f(this).wrapAll(b?a.call(this,c):a)})},unwrap:function(){return this.parent().each(function(){f.nodeName(this,"body")||f(this).replaceWith(this.childNodes)}).end()},append:function(){return this.domManip(arguments,!0,function(a){this.nodeType===1&&this.appendChild(a)})},prepend:function(){return this.domManip(arguments,!0,function(a){this.nodeType===1&&this.insertBefore(a,this.firstChild)})},before:function(){if(this[0]&&this[0].parentNode)return this.domManip(arguments,!1,function(a){this.parentNode.insertBefore(a,this)});if(arguments.length){var a=f.clean(arguments);a.push.apply(a,this.toArray());return this.pushStack(a,"before",arguments)}},after:function(){if(this[0]&&this[0].parentNode)return this.domManip(arguments,!1,function(a){this.parentNode.insertBefore(a,this.nextSibling)});if(arguments.length){var a=this.pushStack(this,"after",arguments);a.push.apply(a,f.clean(arguments));return a}},remove:function(a,b){for(var c=0,d;(d=this[c])!=null;c++)if(!a||f.filter(a,[d]).length)!b&&d.nodeType===1&&(f.cleanData(d.getElementsByTagName("*")),f.cleanData([d])),d.parentNode&&d.parentNode.removeChild(d);return this},empty:function()
{for(var a=0,b;(b=this[a])!=null;a++){b.nodeType===1&&f.cleanData(b.getElementsByTagName("*"));while(b.firstChild)b.removeChild(b.firstChild)}return this},clone:function(a,b){a=a==null?!1:a,b=b==null?a:b;return this.map(function(){return f.clone(this,a,b)})},html:function(a){if(a===b)return this[0]&&this[0].nodeType===1?this[0].innerHTML.replace(W,""):null;if(typeof a=="string"&&!ba.test(a)&&(f.support.leadingWhitespace||!X.test(a))&&!bg[(Z.exec(a)||["",""])[1].toLowerCase()]){a=a.replace(Y,"<$1></$2>");try{for(var c=0,d=this.length;c<d;c++)this[c].nodeType===1&&(f.cleanData(this[c].getElementsByTagName("*")),this[c].innerHTML=a)}catch(e){this.empty().append(a)}}else f.isFunction(a)?this.each(function(b){var c=f(this);c.html(a.call(this,b,c.html()))}):this.empty().append(a);return this},replaceWith:function(a){if(this[0]&&this[0].parentNode){if(f.isFunction(a))return this.each(function(b){var c=f(this),d=c.html();c.replaceWith(a.call(this,b,d))});typeof a!="string"&&(a=f(a).detach());return this.each(function(){var b=this.nextSibling,c=this.parentNode;f(this).remove(),b?f(b).before(a):f(c).append(a)})}return this.length?this.pushStack(f(f.isFunction(a)?a():a),"replaceWith",a):this},detach:function(a){return this.remove(a,!0)},domManip:function(a,c,d){var e,g,h,i,j=a[0],k=[];if(!f.support.checkClone&&arguments.length===3&&typeof j=="string"&&bd.test(j))return this.each(function(){f(this).domManip(a,c,d,!0)});if(f.isFunction(j))return this.each(function(e){var g=f(this);a[0]=j.call(this,e,c?g.html():b),g.domManip(a,c,d)});if(this[0]){i=j&&j.parentNode,f.support.parentNode&&i&&i.nodeType===11&&i.childNodes.length===this.length?e={fragment:i}:e=f.buildFragment(a,this,k),h=e.fragment,h.childNodes.length===1?g=h=h.firstChild:g=h.firstChild;if(g){c=c&&f.nodeName(g,"tr");for(var l=0,m=this.length,n=m-1;l<m;l++)d.call(c?bi(this[l],g):this[l],e.cacheable||m>1&&l<n?f.clone(h,!0,!0):h)}k.length&&f.each(k,bp)}return this}}),f.buildFragment=function(a,b,d){var e,g,h,i,j=a[0];b&&b[0]&&(i=b[0].ownerDocument||b[0]),i.createDocumentFragment||(i=c),a.length===1&&typeof j=="string"&&j.length<512&&i===c&&j.charAt(0)==="<"&&!bb.test(j)&&(f.support.checkClone||!bd.test(j))&&(f.support.html5Clone||!bc.test(j))&&(g=!0,h=f.fragments[j],h&&h!==1&&(e=h)),e||(e=i.createDocumentFragment(),f.clean(a,i,e,d)),g&&(f.fragments[j]=h?e:1);return{fragment:e,cacheable:g}},f.fragments={},f.each({appendTo:"append",prependTo:"prepend",insertBefore:"before",insertAfter:"after",replaceAll:"replaceWith"},function(a,b){f.fn[a]=function(c){var d=[],e=f(c),g=this.length===1&&this[0].parentNode;if(g&&g.nodeType===11&&g.childNodes.length===1&&e.length===1){e[b](this[0]);return this}for(var h=0,i=e.length;h<i;h++){var j=(h>0?this.clone(!0):this).get();f(e[h])[b](j),d=d.concat(j)}return this.pushStack(d,a,e.selector)}}),f.extend({clone:function(a,b,c){var d,e,g,h=f.support.html5Clone||!bc.test("<"+a.nodeName)?a.cloneNode(!0):bo(a);if((!f.support.noCloneEvent||!f.support.noCloneChecked)&&(a.nodeType===1||a.nodeType===11)&&!f.isXMLDoc(a)){bk(a,h),d=bl(a),e=bl(h);for(g=0;d[g];++g)e[g]&&bk(d[g],e[g])}if(b){bj(a,h);if(c){d=bl(a),e=bl(h);for(g=0;d[g];++g)bj(d[g],e[g])}}d=e=null;return h},clean:function(a,b,d,e){var g;b=b||c,typeof b.createElement=="undefined"&&(b=b.ownerDocument||b[0]&&b[0].ownerDocument||c);var h=[],i;for(var j=0,k;(k=a[j])!=null;j++){typeof k=="number"&&(k+="");if(!k)continue;if(typeof k=="string")if(!_.test(k))k=b.createTextNode(k);else{k=k.replace(Y,"<$1></$2>");var l=(Z.exec(k)||["",""])[1].toLowerCase(),m=bg[l]||bg._default,n=m[0],o=b.createElement("div");b===c?bh.appendChild(o):U(b).appendChild(o),o.innerHTML=m[1]+k+m[2];while(n--)o=o.lastChild;if(!f.support.tbody){var p=$.test(k),q=l==="table"&&!p?o.firstChild&&o.firstChild.childNodes:m[1]==="<table>"&&!p?o.childNodes:[];for(i=q.length-1;i>=0;--i)f.nodeName(q[i],"tbody")&&!q[i].childNodes.length&&q[i].parentNode.removeChild(q[i])}!f.support.leadingWhitespace&&X.test(k)&&o.insertBefore(b.createTextNode(X.exec(k)[0]),o.firstChild),k=o.childNodes}var r;if(!f.support.appendChecked)if(k[0]&&typeof (r=k.length)=="number")for(i=0;i<r;i++)bn(k[i]);else bn(k);k.nodeType?h.push(k):h=f.merge(h,k)}if(d){g=function(a){return!a.type||be.test(a.type)};for(j=0;h[j];j++)if(e&&f.nodeName(h[j],"script")&&(!h[j].type||h[j].type.toLowerCase()==="text/javascript"))e.push(h[j].parentNode?h[j].parentNode.removeChild(h[j]):h[j]);else{if(h[j].nodeType===1){var s=f.grep(h[j].getElementsByTagName("script"),g);h.splice.apply(h,[j+1,0].concat(s))}d.appendChild(h[j])}}return h},cleanData:function(a){var b,c,d=f.cache,e=f.event.special,g=f.support.deleteExpando;for(var h=0,i;(i=a[h])!=null;h++){if(i.nodeName&&f.noData[i.nodeName.toLowerCase()])continue;c=i[f.expando];if(c){b=d[c];if(b&&b.events){for(var j in b.events)e[j]?f.event.remove(i,j):f.removeEvent(i,j,b.handle);b.handle&&(b.handle.elem=null)}g?delete i[f.expando]:i.removeAttribute&&i.removeAttribute(f.expando),delete d[c]}}}});var bq=/alpha\([^)]*\)/i,br=/opacity=([^)]*)/,bs=/([A-Z]|^ms)/g,bt=/^-?\d+(?:px)?$/i,bu=/^-?\d/,bv=/^([\-+])=([\-+.\de]+)/,bw={position:"absolute",visibility:"hidden",display:"block"},bx=["Left","Right"],by=["Top","Bottom"],bz,bA,bB;f.fn.css=function(a,c){if(arguments.length===2&&c===b)return this;return f.access(this,a,c,!0,function(a,c,d){return d!==b?f.style(a,c,d):f.css(a,c)})},f.extend({cssHooks:{opacity:{get:function(a,b){if(b){var c=bz(a,"opacity","opacity");return c===""?"1":c}return a.style.opacity}}},cssNumber:{fillOpacity:!0,fontWeight:!0,lineHeight:!0,opacity:!0,orphans:!0,widows:!0,zIndex:!0,zoom:!0},cssProps:{"float":f.support.cssFloat?"cssFloat":"styleFloat"},style:function(a,c,d,e){if(!!a&&a.nodeType!==3&&a.nodeType!==8&&!!a.style){var g,h,i=f.camelCase(c),j=a.style,k=f.cssHooks[i];c=f.cssProps[i]||i;if(d===b){if(k&&"get"in k&&(g=k.get(a,!1,e))!==b)return g;return j[c]}h=typeof d,h==="string"&&(g=bv.exec(d))&&(d=+(g[1]+1)*+g[2]+parseFloat(f.css(a,c)),h="number");if(d==null||h==="number"&&isNaN(d))return;h==="number"&&!f.cssNumber[i]&&(d+="px");if(!k||!("set"in k)||(d=k.set(a,d))!==b)try{j[c]=d}catch(l){}}},css:function(a,c,d){var e,g;c=f.camelCase(c),g=f.cssHooks[c],c=f.cssProps[c]||c,c==="cssFloat"&&(c="float");if(g&&"get"in g&&(e=g.get(a,!0,d))!==b)return e;if(bz)return bz(a,c)},swap:function(a,b,c){var d={};for(var e in b)d[e]=a.style[e],a.style[e]=b[e];c.call(a);for(e in b)a.style[e]=d[e]}}),f.curCSS=f.css,f.each(["height","width"],function(a,b){f.cssHooks[b]={get:function(a,c,d){var e;if(c){if(a.offsetWidth!==0)return bC(a,b,d);f.swap(a,bw,function(){e=bC(a,b,d)});return e}},set:function(a,b){if(!bt.test(b))return b;b=parseFloat(b);if(b>=0)return b+"px"}}}),f.support.opacity||(f.cssHooks.opacity={get:function(a,b){return br.test((b&&a.currentStyle?a.currentStyle.filter:a.style.filter)||"")?parseFloat(RegExp.$1)/100+"":b?"1":""},set:function(a,b){var c=a.style,d=a.currentStyle,e=f.isNumeric(b)?"alpha(opacity="+b*100+")":"",g=d&&d.filter||c.filter||"";c.zoom=1;if(b>=1&&f.trim(g.replace(bq,""))===""){c.removeAttribute("filter");if(d&&!d.filter)return}c.filter=bq.test(g)?g.replace(bq,e):g+" "+e}}),f(function(){f.support.reliableMarginRight||(f.cssHooks.marginRight={get:function(a,b){var c;f.swap(a,{display:"inline-block"},function(){b?c=bz(a,"margin-right","marginRight"):c=a.style.marginRight});return c}})}),c.defaultView&&c.defaultView.getComputedStyle&&(bA=function(a,b){var c,d,e;b=b.replace(bs,"-$1").toLowerCase(),(d=a.ownerDocument.defaultView)&&(e=d.getComputedStyle(a,null))&&(c=e.getPropertyValue(b),c===""&&!f.contains(a.ownerDocument.documentElement,a)&&(c=f.style(a,b)));return c}),c.documentElement.currentStyle&&(bB=function(a,b){var c,d,e,f=a.currentStyle&&a.currentStyle[b],g=a.style;f===null&&g&&(e=g[b])&&(f=e),!bt.test(f)&&bu.test(f)&&(c=g.left,d=a.runtimeStyle&&a.runtimeStyle.left,d&&(a.runtimeStyle.left=a.currentStyle.left),g.left=b==="fontSize"?"1em":f||0,f=g.pixelLeft+"px",g.left=c,d&&(a.runtimeStyle.left=d));return f===""?"auto":f}),bz=bA||bB,f.expr&&f.expr.filters&&(f.expr.filters.hidden=function(a){var b=a.offsetWidth,c=a.offsetHeight;return b===0&&c===0||!f.support.reliableHiddenOffsets&&(a.style&&a.style.display||f.css(a,"display"))==="none"},f.expr.filters.visible=function(a){return!f.expr.filters.hidden(a)});var bD=/%20/g,bE=/\[\]$/,bF=/\r?\n/g,bG=/#.*$/,bH=/^(.*?):[ \t]*([^\r\n]*)\r?$/mg,bI=/^(?:color|date|datetime|datetime-local|email|hidden|month|number|password|range|search|tel|text|time|url|week)$/i,bJ=/^(?:about|app|app\-storage|.+\-extension|file|res|widget):$/,bK=/^(?:GET|HEAD)$/,bL=/^\/\//,bM=/\?/,bN=/<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>/gi,bO=/^(?:select|textarea)/i,bP=/\s+/,bQ=/([?&])_=[^&]*/,bR=/^([\w\+\.\-]+:)(?:\/\/([^\/?#:]*)(?::(\d+))?)?/,bS=f.fn.load,bT={},bU={},bV,bW,bX=["*/"]+["*"];try{bV=e.href}catch(bY){bV=c.createElement("a"),bV.href="",bV=bV.href}bW=bR.exec(bV.toLowerCase())||[],f.fn.extend({load:function(a,c,d){if(typeof a!="string"&&bS)return bS.apply(this,arguments);if(!this.length)return this;var e=a.indexOf(" ");if(e>=0){var g=a.slice(e,a.length);a=a.slice(0,e)}var h="GET";c&&(f.isFunction(c)?(d=c,c=b):typeof c=="object"&&(c=f.param(c,f.ajaxSettings.traditional),h="POST"));var i=this;f.ajax({url:a,type:h,dataType:"html",data:c,complete:function(a,b,c){c=a.responseText,a.isResolved()&&(a.done(function(a){c=a}),i.html(g?f("<div>").append(c.replace(bN,"")).find(g):c)),d&&i.each(d,[c,b,a])}});return this},serialize:function(){return f.param(this.serializeArray())},serializeArray:function(){return this.map(function(){return this.elements?f.makeArray(this.elements):this}).filter(function(){return this.name&&!this.disabled&&(this.checked||bO.test(this.nodeName)||bI.test(this.type))}).map(function(a,b){var c=f(this).val();return c==null?null:f.isArray(c)?f.map(c,function(a,c){return{name:b.name,value:a.replace(bF,"\r\n")}}):{name:b.name,value:c.replace(bF,"\r\n")}}).get()}}),f.each("ajaxStart ajaxStop ajaxComplete ajaxError ajaxSuccess ajaxSend".split(" "),function(a,b){f.fn[b]=function(a){return this.on(b,a)}}),f.each(["get","post"],function(a,c){f[c]=function(a,d,e,g){f.isFunction(d)&&(g=g||e,e=d,d=b);return f.ajax({type:c,url:a,data:d,success:e,dataType:g})}}),f.extend({getScript:function(a,c){return f.get(a,b,c,"script")},getJSON:function(a,b,c){return f.get(a,b,c,"json")},ajaxSetup:function(a,b){b?b_(a,f.ajaxSettings):(b=a,a=f.ajaxSettings),b_(a,b);return a},ajaxSettings:{url:bV,isLocal:bJ.test(bW[1]),global:!0,type:"GET",contentType:"application/x-www-form-urlencoded",processData:!0,async:!0,accepts:{xml:"application/xml, text/xml",html:"text/html",text:"text/plain",json:"application/json, text/javascript","*":bX},contents:{xml:/xml/,html:/html/,json:/json/},responseFields:{xml:"responseXML",text:"responseText"},converters:{"* text":a.String,"text html":!0,"text json":f.parseJSON,"text xml":f.parseXML},flatOptions:{context:!0,url:!0}},ajaxPrefilter:bZ(bT),ajaxTransport:bZ(bU),ajax:function(a,c){function w(a,c,l,m){if(s!==2){s=2,q&&clearTimeout(q),p=b,n=m||"",v.readyState=a>0?4:0;var o,r,u,w=c,x=l?cb(d,v,l):b,y,z;if(a>=200&&a<300||a===304){if(d.ifModified){if(y=v.getResponseHeader("Last-Modified"))f.lastModified[k]=y;if(z=v.getResponseHeader("Etag"))f.etag[k]=z}if(a===304)w="notmodified",o=!0;else try{r=cc(d,x),w="success",o=!0}catch(A){w="parsererror",u=A}}else{u=w;if(!w||a)w="error",a<0&&(a=0)}v.status=a,v.statusText=""+(c||w),o?h.resolveWith(e,[r,w,v]):h.rejectWith(e,[v,w,u]),v.statusCode(j),j=b,t&&g.trigger("ajax"+(o?"Success":"Error"),[v,d,o?r:u]),i.fireWith(e,[v,w]),t&&(g.trigger("ajaxComplete",[v,d]),--f.active||f.event.trigger("ajaxStop"))}}typeof a=="object"&&(c=a,a=b),c=c||{};var d=f.ajaxSetup({},c),e=d.context||d,g=e!==d&&(e.nodeType||e instanceof f)?f(e):f.event,h=f.Deferred(),i=f.Callbacks("once memory"),j=d.statusCode||{},k,l={},m={},n,o,p,q,r,s=0,t,u,v={readyState:0,setRequestHeader:function(a,b){if(!s){var c=a.toLowerCase();a=m[c]=m[c]||a,l[a]=b}return this},getAllResponseHeaders:function(){return s===2?n:null},getResponseHeader:function(a){var c;if(s===2){if(!o){o={};while(c=bH.exec(n))o[c[1].toLowerCase()]=c[2]}c=o[a.toLowerCase()]}return c===b?null:c},overrideMimeType:function(a){s||(d.mimeType=a);return this},abort:function(a){a=a||"abort",p&&p.abort(a),w(0,a);return this}};h.promise(v),v.success=v.done,v.error=v.fail,v.complete=i.add,v.statusCode=function(a){if(a){var b;if(s<2)for(b in a)j[b]=[j[b],a[b]];else b=a[v.status],v.then(b,b)}return this},d.url=((a||d.url)+"").replace(bG,"").replace(bL,bW[1]+"//"),d.dataTypes=f.trim(d.dataType||"*").toLowerCase().split(bP),d.crossDomain==null&&(r=bR.exec(d.url.toLowerCase()),d.crossDomain=!(!r||r[1]==bW[1]&&r[2]==bW[2]&&(r[3]||(r[1]==="http:"?80:443))==(bW[3]||(bW[1]==="http:"?80:443)))),d.data&&d.processData&&typeof d.data!="string"&&(d.data=f.param(d.data,d.traditional)),b$(bT,d,c,v);if(s===2)return!1;t=d.global,d.type=d.type.toUpperCase(),d.hasContent=!bK.test(d.type),t&&f.active++===0&&f.event.trigger("ajaxStart");if(!d.hasContent){d.data&&(d.url+=(bM.test(d.url)?"&":"?")+d.data,delete d.data),k=d.url;if(d.cache===!1){var x=f.now(),y=d.url.replace(bQ,"$1_="+x);d.url=y+(y===d.url?(bM.test(d.url)?"&":"?")+"_="+x:"")}}(d.data&&d.hasContent&&d.contentType!==!1||c.contentType)&&v.setRequestHeader("Content-Type",d.contentType),d.ifModified&&(k=k||d.url,f.lastModified[k]&&v.setRequestHeader("If-Modified-Since",f.lastModified[k]),f.etag[k]&&v.setRequestHeader("If-None-Match",f.etag[k])),v.setRequestHeader("Accept",d.dataTypes[0]&&d.accepts[d.dataTypes[0]]?d.accepts[d.dataTypes[0]]+(d.dataTypes[0]!=="*"?", "+bX+"; q=0.01":""):d.accepts["*"]);for(u in d.headers)v.setRequestHeader(u,d.headers[u]);if(d.beforeSend&&(d.beforeSend.call(e,v,d)===!1||s===2)){v.abort();return!1}for(u in{success:1,error:1,complete:1})v[u](d[u]);p=b$(bU,d,c,v);if(!p)w(-1,"No Transport");else{v.readyState=1,t&&g.trigger("ajaxSend",[v,d]),d.async&&d.timeout>0&&(q=setTimeout(function(){v.abort("timeout")},d.timeout));try{s=1,p.send(l,w)}catch(z){if(s<2)w(-1,z);else throw z}}return v},param:function(a,c){var d=[],e=function(a,b){b=f.isFunction(b)?b():b,d[d.length]=encodeURIComponent(a)+"="+encodeURIComponent(b)};c===b&&(c=f.ajaxSettings.traditional);if(f.isArray(a)||a.jquery&&!f.isPlainObject(a))f.each(a,function(){e(this.name,this.value)});else for(var g in a)ca(g,a[g],c,e);return d.join("&").replace(bD,"+")}}),f.extend({active:0,lastModified:{},etag:{}});var cd=f.now(),ce=/(\=)\?(&|$)|\?\?/i;f.ajaxSetup({jsonp:"callback",jsonpCallback:function(){return f.expando+"_"+cd++}}),f.ajaxPrefilter("json jsonp",function(b,c,d){var e=b.contentType==="application/x-www-form-urlencoded"&&typeof b.data=="string";if(b.dataTypes[0]==="jsonp"||b.jsonp!==!1&&(ce.test(b.url)||e&&ce.test(b.data))){var g,h=b.jsonpCallback=f.isFunction(b.jsonpCallback)?b.jsonpCallback():b.jsonpCallback,i=a[h],j=b.url,k=b.data,l="$1"+h+"$2";b.jsonp!==!1&&(j=j.replace(ce,l),b.url===j&&(e&&(k=k.replace(ce,l)),b.data===k&&(j+=(/\?/.test(j)?"&":"?")+b.jsonp+"="+h))),b.url=j,b.data=k,a[h]=function(a){g=[a]},d.always(function(){a[h]=i,g&&f.isFunction(i)&&a[h](g[0])}),b.converters["script json"]=function(){g||f.error(h+" was not called");return g[0]},b.dataTypes[0]="json";return"script"}}),f.ajaxSetup({accepts:{script:"text/javascript, application/javascript, application/ecmascript, application/x-ecmascript"},contents:{script:/javascript|ecmascript/},converters:{"text script":function(a){f.globalEval(a);return a}}}),f.ajaxPrefilter("script",function(a){a.cache===b&&(a.cache=!1),a.crossDomain&&(a.type="GET",a.global=!1)}),f.ajaxTransport("script",function(a){if(a.crossDomain){var d,e=c.head||c.getElementsByTagName("head")[0]||c.documentElement;return{send:function(f,g){d=c.createElement("script"),d.async="async",a.scriptCharset&&(d.charset=a.scriptCharset),d.src=a.url,d.onload=d.onreadystatechange=function(a,c){if(c||!d.readyState||/loaded|complete/.test(d.readyState))d.onload=d.onreadystatechange=null,e&&d.parentNode&&e.removeChild(d),d=b,c||g(200,"success")},e.insertBefore(d,e.firstChild)},abort:function(){d&&d.onload(0,1)}}}});var cf=a.ActiveXObject?function(){for(var a in ch)ch[a](0,1)}:!1,cg=0,ch;f.ajaxSettings.xhr=a.ActiveXObject?function(){return!this.isLocal&&ci()||cj()}:ci,function(a){f.extend(f.support,{ajax:!!a,cors:!!a&&"withCredentials"in a})}(f.ajaxSettings.xhr()),f.support.ajax&&f.ajaxTransport(function(c){if(!c.crossDomain||f.support.cors){var d;return{send:function(e,g){var h=c.xhr(),i,j;c.username?h.open(c.type,c.url,c.async,c.username,c.password):h.open(c.type,c.url,c.async);if(c.xhrFields)for(j in c.xhrFields)h[j]=c.xhrFields[j];c.mimeType&&h.overrideMimeType&&h.overrideMimeType(c.mimeType),!c.crossDomain&&!e["X-Requested-With"]&&(e["X-Requested-With"]="XMLHttpRequest");try{for(j in e)h.setRequestHeader(j,e[j])}catch(k){}h.send(c.hasContent&&c.data||null),d=function(a,e){var j,k,l,m,n;try{if(d&&(e||h.readyState===4)){d=b,i&&(h.onreadystatechange=f.noop,cf&&delete ch[i]);if(e)h.readyState!==4&&h.abort();else{j=h.status,l=h.getAllResponseHeaders(),m={},n=h.responseXML,n&&n.documentElement&&(m.xml=n),m.text=h.responseText;try{k=h.statusText}catch(o){k=""}!j&&c.isLocal&&!c.crossDomain?j=m.text?200:404:j===1223&&(j=204)}}}catch(p){e||g(-1,p)}m&&g(j,k,m,l)},!c.async||h.readyState===4?d():(i=++cg,cf&&(ch||(ch={},f(a).unload(cf)),ch[i]=d),h.onreadystatechange=d)},abort:function(){d&&d(0,1)}}}});var ck={},cl,cm,cn=/^(?:toggle|show|hide)$/,co=/^([+\-]=)?([\d+.\-]+)([a-z%]*)$/i,cp,cq=[["height","marginTop","marginBottom","paddingTop","paddingBottom"],["width","marginLeft","marginRight","paddingLeft","paddingRight"],["opacity"]],cr;f.fn.extend({show:function(a,b,c){var d,e;if(a||a===0)return this.animate(cu("show",3),a,b,c);for(var g=0,h=this.length;g<h;g++)d=this[g],d.style&&(e=d.style.display,!f._data(d,"olddisplay")&&e==="none"&&(e=d.style.display=""),e===""&&f.css(d,"display")==="none"&&f._data(d,"olddisplay",cv(d.nodeName)));for(g=0;g<h;g++){d=this[g];if(d.style){e=d.style.display;if(e===""||e==="none")d.style.display=f._data(d,"olddisplay")||""}}return this},hide:function(a,b,c){if(a||a===0)return this.animate(cu("hide",3),a,b,c);var d,e,g=0,h=this.length;for(;g<h;g++)d=this[g],d.style&&(e=f.css(d,"display"),e!=="none"&&!f._data(d,"olddisplay")&&f._data(d,"olddisplay",e));for(g=0;g<h;g++)this[g].style&&(this[g].style.display="none");return this},_toggle:f.fn.toggle,toggle:function(a,b,c){var d=typeof a=="boolean";f.isFunction(a)&&f.isFunction(b)?this._toggle.apply(this,arguments):a==null||d?this.each(function(){var b=d?a:f(this).is(":hidden");f(this)[b?"show":"hide"]()}):this.animate(cu("toggle",3),a,b,c);return this},fadeTo:function(a,b,c,d){return this.filter(":hidden").css("opacity",0).show().end().animate({opacity:b},a,c,d)},animate:function(a,b,c,d){function g(){e.queue===!1&&f._mark(this);var b=f.extend({},e),c=this.nodeType===1,d=c&&f(this).is(":hidden"),g,h,i,j,k,l,m,n,o;b.animatedProperties={};for(i in a){g=f.camelCase(i),i!==g&&(a[g]=a[i],delete a[i]),h=a[g],f.isArray(h)?(b.animatedProperties[g]=h[1],h=a[g]=h[0]):b.animatedProperties[g]=b.specialEasing&&b.specialEasing[g]||b.easing||"swing";if(h==="hide"&&d||h==="show"&&!d)return b.complete.call(this);c&&(g==="height"||g==="width")&&(b.overflow=[this.style.overflow,this.style.overflowX,this.style.overflowY],f.css(this,"display")==="inline"&&f.css(this,"float")==="none"&&(!f.support.inlineBlockNeedsLayout||cv(this.nodeName)==="inline"?this.style.display="inline-block":this.style.zoom=1))}b.overflow!=null&&(this.style.overflow="hidden");for(i in a)j=new f.fx(this,b,i),h=a[i],cn.test(h)?(o=f._data(this,"toggle"+i)||(h==="toggle"?d?"show":"hide":0),o?(f._data(this,"toggle"+i,o==="show"?"hide":"show"),j[o]()):j[h]()):(k=co.exec(h),l=j.cur(),k?(m=parseFloat(k[2]),n=k[3]||(f.cssNumber[i]?"":"px"),n!=="px"&&(f.style(this,i,(m||1)+n),l=(m||1)/j.cur()*l,f.style(this,i,l+n)),k[1]&&(m=(k[1]==="-="?-1:1)*m+l),j.custom(l,m,n)):j.custom(l,h,""));return!0}var e=f.speed(b,c,d);if(f.isEmptyObject(a))return this.each(e.complete,[!1]);a=f.extend({},a);return e.queue===!1?this.each(g):this.queue(e.queue,g)},stop:function(a,c,d){typeof a!="string"&&(d=c,c=a,a=b),c&&a!==!1&&this.queue(a||"fx",[]);return this.each(function(){function h(a,b,c){var e=b[c];f.removeData(a,c,!0),e.stop(d)}var b,c=!1,e=f.timers,g=f._data(this);d||f._unmark(!0,this);if(a==null)for(b in g)g[b]&&g[b].stop&&b.indexOf(".run")===b.length-4&&h(this,g,b);else g[b=a+".run"]&&g[b].stop&&h(this,g,b);for(b=e.length;b--;)e[b].elem===this&&(a==null||e[b].queue===a)&&(d?e[b](!0):e[b].saveState(),c=!0,e.splice(b,1));(!d||!c)&&f.dequeue(this,a)})}}),f.each({slideDown:cu("show",1),slideUp:cu("hide",1),slideToggle:cu("toggle",1),fadeIn:{opacity:"show"},fadeOut:{opacity:"hide"},fadeToggle:{opacity:"toggle"}},function(a,b){f.fn[a]=function(a,c,d){return this.animate(b,a,c,d)}}),f.extend({speed:function(a,b,c){var d=a&&typeof a=="object"?f.extend({},a):{complete:c||!c&&b||f.isFunction(a)&&a,duration:a,easing:c&&b||b&&!f.isFunction(b)&&b};d.duration=f.fx.off?0:typeof d.duration=="number"?d.duration:d.duration in f.fx.speeds?f.fx.speeds[d.duration]:f.fx.speeds._default;if(d.queue==null||d.queue===!0)d.queue="fx";d.old=d.complete,d.complete=function(a){f.isFunction(d.old)&&d.old.call(this),d.queue?f.dequeue(this,d.queue):a!==!1&&f._unmark(this)};return d},easing:{linear:function(a,b,c,d){return c+d*a},swing:function(a,b,c,d){return(-Math.cos(a*Math.PI)/2+.5)*d+c}},timers:[],fx:function(a,b,c){this.options=b,this.elem=a,this.prop=c,b.orig=b.orig||{}}}),f.fx.prototype={update:function(){this.options.step&&this.options.step.call(this.elem,this.now,this),(f.fx.step[this.prop]||f.fx.step._default)(this)},cur:function(){if(this.elem[this.prop]!=null&&(!this.elem.style||this.elem.style[this.prop]==null))return this.elem[this.prop];var a,b=f.css(this.elem,this.prop);return isNaN(a=parseFloat(b))?!b||b==="auto"?0:b:a},custom:function(a,c,d){function h(a){return e.step(a)}var e=this,g=f.fx;this.startTime=cr||cs(),this.end=c,this.now=this.start=a,this.pos=this.state=0,this.unit=d||this.unit||(f.cssNumber[this.prop]?"":"px"),h.queue=this.options.queue,h.elem=this.elem,h.saveState=function(){e.options.hide&&f._data(e.elem,"fxshow"+e.prop)===b&&f._data(e.elem,"fxshow"+e.prop,e.start)},h()&&f.timers.push(h)&&!cp&&(cp=setInterval(g.tick,g.interval))},show:function(){var a=f._data(this.elem,"fxshow"+this.prop);this.options.orig[this.prop]=a||f.style(this.elem,this.prop),this.options.show=!0,a!==b?this.custom(this.cur(),a):this.custom(this.prop==="width"||this.prop==="height"?1:0,this.cur()),f(this.elem).show()},hide:function(){this.options.orig[this.prop]=f._data(this.elem,"fxshow"+this.prop)||f.style(this.elem,this.prop),this.options.hide=!0,this.custom(this.cur(),0)},step:function(a){var b,c,d,e=cr||cs(),g=!0,h=this.elem,i=this.options;if(a||e>=i.duration+this.startTime){this.now=this.end,this.pos=this.state=1,this.update(),i.animatedProperties[this.prop]=!0;for(b in i.animatedProperties)i.animatedProperties[b]!==!0&&(g=!1);if(g){i.overflow!=null&&!f.support.shrinkWrapBlocks&&f.each(["","X","Y"],function(a,b){h.style["overflow"+b]=i.overflow[a]}),i.hide&&f(h).hide();if(i.hide||i.show)for(b in i.animatedProperties)f.style(h,b,i.orig[b]),f.removeData(h,"fxshow"+b,!0),f.removeData(h,"toggle"+b,!0);d=i.complete,d&&(i.complete=!1,d.call(h))}return!1}i.duration==Infinity?this.now=e:(c=e-this.startTime,this.state=c/i.duration,this.pos=f.easing[i.animatedProperties[this.prop]](this.state,c,0,1,i.duration),this.now=this.start+(this.end-this.start)*this.pos),this.update();return!0}},f.extend(f.fx,{tick:function(){var a,b=f.timers,c=0;for(;c<b.length;c++)a=b[c],!a()&&b[c]===a&&b.splice(c--,1);b.length||f.fx.stop()},interval:13,stop:function(){clearInterval(cp),cp=null},speeds:{slow:600,fast:200,_default:400},step:{opacity:function(a){f.style(a.elem,"opacity",a.now)},_default:function(a){a.elem.style&&a.elem.style[a.prop]!=null?a.elem.style[a.prop]=a.now+a.unit:a.elem[a.prop]=a.now}}}),f.each(["width","height"],function(a,b){f.fx.step[b]=function(a){f.style(a.elem,b,Math.max(0,a.now)+a.unit)}}),f.expr&&f.expr.filters&&(f.expr.filters.animated=function(a){return f.grep(f.timers,function(b){return a===b.elem}).length});var cw=/^t(?:able|d|h)$/i,cx=/^(?:body|html)$/i;"getBoundingClientRect"in c.documentElement?f.fn.offset=function(a){var b=this[0],c;if(a)return this.each(function(b){f.offset.setOffset(this,a,b)});if(!b||!b.ownerDocument)return null;if(b===b.ownerDocument.body)return f.offset.bodyOffset(b);try{c=b.getBoundingClientRect()}catch(d){}var e=b.ownerDocument,g=e.documentElement;if(!c||!f.contains(g,b))return c?{top:c.top,left:c.left}:{top:0,left:0};var h=e.body,i=cy(e),j=g.clientTop||h.clientTop||0,k=g.clientLeft||h.clientLeft||0,l=i.pageYOffset||f.support.boxModel&&g.scrollTop||h.scrollTop,m=i.pageXOffset||f.support.boxModel&&g.scrollLeft||h.scrollLeft,n=c.top+l-j,o=c.left+m-k;return{top:n,left:o}}:f.fn.offset=function(a){var b=this[0];if(a)return this.each(function(b){f.offset.setOffset(this,a,b)});if(!b||!b.ownerDocument)return null;if(b===b.ownerDocument.body)return f.offset.bodyOffset(b);var c,d=b.offsetParent,e=b,g=b.ownerDocument,h=g.documentElement,i=g.body,j=g.defaultView,k=j?j.getComputedStyle(b,null):b.currentStyle,l=b.offsetTop,m=b.offsetLeft;while((b=b.parentNode)&&b!==i&&b!==h){if(f.support.fixedPosition&&k.position==="fixed")break;c=j?j.getComputedStyle(b,null):b.currentStyle,l-=b.scrollTop,m-=b.scrollLeft,b===d&&(l+=b.offsetTop,m+=b.offsetLeft,f.support.doesNotAddBorder&&(!f.support.doesAddBorderForTableAndCells||!cw.test(b.nodeName))&&(l+=parseFloat(c.borderTopWidth)||0,m+=parseFloat(c.borderLeftWidth)||0),e=d,d=b.offsetParent),f.support.subtractsBorderForOverflowNotVisible&&c.overflow!=="visible"&&(l+=parseFloat(c.borderTopWidth)||0,m+=parseFloat(c.borderLeftWidth)||0),k=c}if(k.position==="relative"||k.position==="static")l+=i.offsetTop,m+=i.offsetLeft;f.support.fixedPosition&&k.position==="fixed"&&(l+=Math.max(h.scrollTop,i.scrollTop),m+=Math.max(h.scrollLeft,i.scrollLeft));return{top:l,left:m}},f.offset={bodyOffset:function(a){var b=a.offsetTop,c=a.offsetLeft;f.support.doesNotIncludeMarginInBodyOffset&&(b+=parseFloat(f.css(a,"marginTop"))||0,c+=parseFloat(f.css(a,"marginLeft"))||0);return{top:b,left:c}},setOffset:function(a,b,c){var d=f.css(a,"position");d==="static"&&(a.style.position="relative");var e=f(a),g=e.offset(),h=f.css(a,"top"),i=f.css(a,"left"),j=(d==="absolute"||d==="fixed")&&f.inArray("auto",[h,i])>-1,k={},l={},m,n;j?(l=e.position(),m=l.top,n=l.left):(m=parseFloat(h)||0,n=parseFloat(i)||0),f.isFunction(b)&&(b=b.call(a,c,g)),b.top!=null&&(k.top=b.top-g.top+m),b.left!=null&&(k.left=b.left-g.left+n),"using"in b?b.using.call(a,k):e.css(k)}},f.fn.extend({position:function(){if(!this[0])return null;var a=this[0],b=this.offsetParent(),c=this.offset(),d=cx.test(b[0].nodeName)?{top:0,left:0}:b.offset();c.top-=parseFloat(f.css(a,"marginTop"))||0,c.left-=parseFloat(f.css(a,"marginLeft"))||0,d.top+=parseFloat(f.css(b[0],"borderTopWidth"))||0,d.left+=parseFloat(f.css(b[0],"borderLeftWidth"))||0;return{top:c.top-d.top,left:c.left-d.left}},offsetParent:function(){return this.map(function(){var a=this.offsetParent||c.body;while(a&&!cx.test(a.nodeName)&&f.css(a,"position")==="static")a=a.offsetParent;return a})}}),f.each(["Left","Top"],function(a,c){var d="scroll"+c;f.fn[d]=function(c){var e,g;if(c===b){e=this[0];if(!e)return null;g=cy(e);return g?"pageXOffset"in g?g[a?"pageYOffset":"pageXOffset"]:f.support.boxModel&&g.document.documentElement[d]||g.document.body[d]:e[d]}return this.each(function(){g=cy(this),g?g.scrollTo(a?f(g).scrollLeft():c,a?c:f(g).scrollTop()):this[d]=c})}}),f.each(["Height","Width"],function(a,c){var d=c.toLowerCase();f.fn["inner"+c]=function(){var a=this[0];return a?a.style?parseFloat(f.css(a,d,"padding")):this[d]():null},f.fn["outer"+c]=function(a){var b=this[0];return b?b.style?parseFloat(f.css(b,d,a?"margin":"border")):this[d]():null},f.fn[d]=function(a){var e=this[0];if(!e)return a==null?null:this;if(f.isFunction(a))return this.each(function(b){var c=f(this);c[d](a.call(this,b,c[d]()))});if(f.isWindow(e)){var g=e.document.documentElement["client"+c],h=e.document.body;return e.document.compatMode==="CSS1Compat"&&g||h&&h["client"+c]||g}if(e.nodeType===9)return Math.max(e.documentElement["client"+c],e.body["scroll"+c],e.documentElement["scroll"+c],e.body["offset"+c],e.documentElement["offset"+c]);if(a===b){var i=f.css(e,d),j=parseFloat(i);return f.isNumeric(j)?j:i}return this.css(d,typeof a=="string"?a:a+"px")}}),a.jQuery=a.$=f,typeof define=="function"&&define.amd&&define.amd.jQuery&&define("jquery",[],function(){return f})})(window);;




try	{
	//var jQuery = $jquery_171 = $jquery = window.jQuery.noConflict(true);
	var $jquery = window.jQuery.noConflict(true);
} catch(e)	{
	var $jquery = jQuery;
}


//(function(jQuery) {
  // ... the jQuery UI lib code for jQuery 1.3.2
(function () {
	var document = window.document;
	
	/*! jQuery UI - v1.8.19 - 2012-04-16
	* https://github.com/jquery/jquery-ui
	* Includes: jquery.ui.core.js
	* Copyright (c) 2012 AUTHORS.txt; Licensed MIT, GPL */
	(function(a,b){function c(b,c){var e=b.nodeName.toLowerCase();if("area"===e){var f=b.parentNode,g=f.name,h;return!b.href||!g||f.nodeName.toLowerCase()!=="map"?!1:(h=a("img[usemap=#"+g+"]")[0],!!h&&d(h))}return(/input|select|textarea|button|object/.test(e)?!b.disabled:"a"==e?b.href||c:c)&&d(b)}function d(b){return!a(b).parents().andSelf().filter(function(){return a.curCSS(this,"visibility")==="hidden"||a.expr.filters.hidden(this)}).length}a.ui=a.ui||{};if(a.ui.version)return;a.extend(a.ui,{version:"1.8.19",keyCode:{ALT:18,BACKSPACE:8,CAPS_LOCK:20,COMMA:188,COMMAND:91,COMMAND_LEFT:91,COMMAND_RIGHT:93,CONTROL:17,DELETE:46,DOWN:40,END:35,ENTER:13,ESCAPE:27,HOME:36,INSERT:45,LEFT:37,MENU:93,NUMPAD_ADD:107,NUMPAD_DECIMAL:110,NUMPAD_DIVIDE:111,NUMPAD_ENTER:108,NUMPAD_MULTIPLY:106,NUMPAD_SUBTRACT:109,PAGE_DOWN:34,PAGE_UP:33,PERIOD:190,RIGHT:39,SHIFT:16,SPACE:32,TAB:9,UP:38,WINDOWS:91}}),a.fn.extend({propAttr:a.fn.prop||a.fn.attr,_focus:a.fn.focus,focus:function(b,c){return typeof b=="number"?this.each(function(){var d=this;setTimeout(function(){a(d).focus(),c&&c.call(d)},b)}):this._focus.apply(this,arguments)},scrollParent:function(){var b;return a.browser.msie&&/(static|relative)/.test(this.css("position"))||/absolute/.test(this.css("position"))?b=this.parents().filter(function(){return/(relative|absolute|fixed)/.test(a.curCSS(this,"position",1))&&/(auto|scroll)/.test(a.curCSS(this,"overflow",1)+a.curCSS(this,"overflow-y",1)+a.curCSS(this,"overflow-x",1))}).eq(0):b=this.parents().filter(function(){return/(auto|scroll)/.test(a.curCSS(this,"overflow",1)+a.curCSS(this,"overflow-y",1)+a.curCSS(this,"overflow-x",1))}).eq(0),/fixed/.test(this.css("position"))||!b.length?a(document):b},zIndex:function(c){if(c!==b)return this.css("zIndex",c);if(this.length){var d=a(this[0]),e,f;while(d.length&&d[0]!==document){e=d.css("position");if(e==="absolute"||e==="relative"||e==="fixed"){f=parseInt(d.css("zIndex"),10);if(!isNaN(f)&&f!==0)return f}d=d.parent()}}return 0},disableSelection:function(){return this.bind((a.support.selectstart?"selectstart":"mousedown")+".ui-disableSelection",function(a){a.preventDefault()})},enableSelection:function(){return this.unbind(".ui-disableSelection")}}),a.each(["Width","Height"],function(c,d){function h(b,c,d,f){return a.each(e,function(){c-=parseFloat(a.curCSS(b,"padding"+this,!0))||0,d&&(c-=parseFloat(a.curCSS(b,"border"+this+"Width",!0))||0),f&&(c-=parseFloat(a.curCSS(b,"margin"+this,!0))||0)}),c}var e=d==="Width"?["Left","Right"]:["Top","Bottom"],f=d.toLowerCase(),g={innerWidth:a.fn.innerWidth,innerHeight:a.fn.innerHeight,outerWidth:a.fn.outerWidth,outerHeight:a.fn.outerHeight};a.fn["inner"+d]=function(c){return c===b?g["inner"+d].call(this):this.each(function(){a(this).css(f,h(this,c)+"px")})},a.fn["outer"+d]=function(b,c){return typeof b!="number"?g["outer"+d].call(this,b):this.each(function(){a(this).css(f,h(this,b,!0,c)+"px")})}}),a.extend(a.expr[":"],{data:function(b,c,d){return!!a.data(b,d[3])},focusable:function(b){return c(b,!isNaN(a.attr(b,"tabindex")))},tabbable:function(b){var d=a.attr(b,"tabindex"),e=isNaN(d);return(e||d>=0)&&c(b,!e)}}),a(function(){var b=document.body,c=b.appendChild(c=document.createElement("div"));c.offsetHeight,a.extend(c.style,{minHeight:"100px",height:"auto",padding:0,borderWidth:0}),a.support.minHeight=c.offsetHeight===100,a.support.selectstart="onselectstart"in c,b.removeChild(c).style.display="none"}),a.extend(a.ui,{plugin:{add:function(b,c,d){var e=a.ui[b].prototype;for(var f in d)e.plugins[f]=e.plugins[f]||[],e.plugins[f].push([c,d[f]])},call:function(a,b,c){var d=a.plugins[b];if(!d||!a.element[0].parentNode)return;for(var e=0;e<d.length;e++)a.options[d[e][0]]&&d[e][1].apply(a.element,c)}},contains:function(a,b){return document.compareDocumentPosition?a.compareDocumentPosition(b)&16:a!==b&&a.contains(b)},hasScroll:function(b,c){if(a(b).css("overflow")==="hidden")return!1;var d=c&&c==="left"?"scrollLeft":"scrollTop",e=!1;return b[d]>0?!0:(b[d]=1,e=b[d]>0,b[d]=0,e)},isOverAxis:function(a,b,c){return a>b&&a<b+c},isOver:function(b,c,d,e,f,g){return a.ui.isOverAxis(b,d,f)&&a.ui.isOverAxis(c,e,g)}})})($jquery);/*! jQuery UI - v1.8.19 - 2012-04-16
	* https://github.com/jquery/jquery-ui
	* Includes: jquery.ui.widget.js
	* Copyright (c) 2012 AUTHORS.txt; Licensed MIT, GPL */
	(function(a,b){if(a.cleanData){var c=a.cleanData;a.cleanData=function(b){for(var d=0,e;(e=b[d])!=null;d++)try{a(e).triggerHandler("remove")}catch(f){}c(b)}}else{var d=a.fn.remove;a.fn.remove=function(b,c){return this.each(function(){return c||(!b||a.filter(b,[this]).length)&&a("*",this).add([this]).each(function(){try{a(this).triggerHandler("remove")}catch(b){}}),d.call(a(this),b,c)})}}a.widget=function(b,c,d){var e=b.split(".")[0],f;b=b.split(".")[1],f=e+"-"+b,d||(d=c,c=a.Widget),a.expr[":"][f]=function(c){return!!a.data(c,b)},a[e]=a[e]||{},a[e][b]=function(a,b){arguments.length&&this._createWidget(a,b)};var g=new c;g.options=a.extend(!0,{},g.options),a[e][b].prototype=a.extend(!0,g,{namespace:e,widgetName:b,widgetEventPrefix:a[e][b].prototype.widgetEventPrefix||b,widgetBaseClass:f},d),a.widget.bridge(b,a[e][b])},a.widget.bridge=function(c,d){a.fn[c]=function(e){var f=typeof e=="string",g=Array.prototype.slice.call(arguments,1),h=this;return e=!f&&g.length?a.extend.apply(null,[!0,e].concat(g)):e,f&&e.charAt(0)==="_"?h:(f?this.each(function(){var d=a.data(this,c),f=d&&a.isFunction(d[e])?d[e].apply(d,g):d;if(f!==d&&f!==b)return h=f,!1}):this.each(function(){var b=a.data(this,c);b?b.option(e||{})._init():a.data(this,c,new d(e,this))}),h)}},a.Widget=function(a,b){arguments.length&&this._createWidget(a,b)},a.Widget.prototype={widgetName:"widget",widgetEventPrefix:"",options:{disabled:!1},_createWidget:function(b,c){a.data(c,this.widgetName,this),this.element=a(c),this.options=a.extend(!0,{},this.options,this._getCreateOptions(),b);var d=this;this.element.bind("remove."+this.widgetName,function(){d.destroy()}),this._create(),this._trigger("create"),this._init()},_getCreateOptions:function(){return a.metadata&&a.metadata.get(this.element[0])[this.widgetName]},_create:function(){},_init:function(){},destroy:function(){this.element.unbind("."+this.widgetName).removeData(this.widgetName),this.widget().unbind("."+this.widgetName).removeAttr("aria-disabled").removeClass(this.widgetBaseClass+"-disabled "+"ui-state-disabled")},widget:function(){return this.element},option:function(c,d){var e=c;if(arguments.length===0)return a.extend({},this.options);if(typeof c=="string"){if(d===b)return this.options[c];e={},e[c]=d}return this._setOptions(e),this},_setOptions:function(b){var c=this;return a.each(b,function(a,b){c._setOption(a,b)}),this},_setOption:function(a,b){return this.options[a]=b,a==="disabled"&&this.widget()[b?"addClass":"removeClass"](this.widgetBaseClass+"-disabled"+" "+"ui-state-disabled").attr("aria-disabled",b),this},enable:function(){return this._setOption("disabled",!1)},disable:function(){return this._setOption("disabled",!0)},_trigger:function(b,c,d){var e,f,g=this.options[b];d=d||{},c=a.Event(c),c.type=(b===this.widgetEventPrefix?b:this.widgetEventPrefix+b).toLowerCase(),c.target=this.element[0],f=c.originalEvent;if(f)for(e in f)e in c||(c[e]=f[e]);return this.element.trigger(c,d),!(a.isFunction(g)&&g.call(this.element[0],c,d)===!1||c.isDefaultPrevented())}}})($jquery);/*! jQuery UI - v1.8.19 - 2012-04-16

	//* https://github.com/jquery/jquery-ui
	//* Includes: jquery.ui.position.js
	//* Copyright (c) 2012 AUTHORS.txt; Licensed MIT, GPL */
	(function(a,b){a.ui=a.ui||{};var c=/left|center|right/,d=/top|center|bottom/,e="center",f={},g=a.fn.position,h=a.fn.offset;a.fn.position=function(b){if(!b||!b.of)return g.apply(this,arguments);b=a.extend({},b);var h=a(b.of),i=h[0],j=(b.collision||"flip").split(" "),k=b.offset?b.offset.split(" "):[0,0],l,m,n;return i.nodeType===9?(l=h.width(),m=h.height(),n={top:0,left:0}):i.setTimeout?(l=h.width(),m=h.height(),n={top:h.scrollTop(),left:h.scrollLeft()}):i.preventDefault?(b.at="left top",l=m=0,n={top:b.of.pageY,left:b.of.pageX}):(l=h.outerWidth(),m=h.outerHeight(),n=h.offset()),a.each(["my","at"],function(){var a=(b[this]||"").split(" ");a.length===1&&(a=c.test(a[0])?a.concat([e]):d.test(a[0])?[e].concat(a):[e,e]),a[0]=c.test(a[0])?a[0]:e,a[1]=d.test(a[1])?a[1]:e,b[this]=a}),j.length===1&&(j[1]=j[0]),k[0]=parseInt(k[0],10)||0,k.length===1&&(k[1]=k[0]),k[1]=parseInt(k[1],10)||0,b.at[0]==="right"?n.left+=l:b.at[0]===e&&(n.left+=l/2),b.at[1]==="bottom"?n.top+=m:b.at[1]===e&&(n.top+=m/2),n.left+=k[0],n.top+=k[1],this.each(function(){var c=a(this),d=c.outerWidth(),g=c.outerHeight(),h=parseInt(a.curCSS(this,"marginLeft",!0))||0,i=parseInt(a.curCSS(this,"marginTop",!0))||0,o=d+h+(parseInt(a.curCSS(this,"marginRight",!0))||0),p=g+i+(parseInt(a.curCSS(this,"marginBottom",!0))||0),q=a.extend({},n),r;b.my[0]==="right"?q.left-=d:b.my[0]===e&&(q.left-=d/2),b.my[1]==="bottom"?q.top-=g:b.my[1]===e&&(q.top-=g/2),f.fractions||(q.left=Math.round(q.left),q.top=Math.round(q.top)),r={left:q.left-h,top:q.top-i},a.each(["left","top"],function(c,e){a.ui.position[j[c]]&&a.ui.position[j[c]][e](q,{targetWidth:l,targetHeight:m,elemWidth:d,elemHeight:g,collisionPosition:r,collisionWidth:o,collisionHeight:p,offset:k,my:b.my,at:b.at})}),a.fn.bgiframe&&c.bgiframe(),c.offset(a.extend(q,{using:b.using}))})},a.ui.position={fit:{left:function(b,c){var d=a(window),e=c.collisionPosition.left+c.collisionWidth-d.width()-d.scrollLeft();b.left=e>0?b.left-e:Math.max(b.left-c.collisionPosition.left,b.left)},top:function(b,c){var d=a(window),e=c.collisionPosition.top+c.collisionHeight-d.height()-d.scrollTop();b.top=e>0?b.top-e:Math.max(b.top-c.collisionPosition.top,b.top)}},flip:{left:function(b,c){if(c.at[0]===e)return;var d=a(window),f=c.collisionPosition.left+c.collisionWidth-d.width()-d.scrollLeft(),g=c.my[0]==="left"?-c.elemWidth:c.my[0]==="right"?c.elemWidth:0,h=c.at[0]==="left"?c.targetWidth:-c.targetWidth,i=-2*c.offset[0];b.left+=c.collisionPosition.left<0?g+h+i:f>0?g+h+i:0},top:function(b,c){if(c.at[1]===e)return;var d=a(window),f=c.collisionPosition.top+c.collisionHeight-d.height()-d.scrollTop(),g=c.my[1]==="top"?-c.elemHeight:c.my[1]==="bottom"?c.elemHeight:0,h=c.at[1]==="top"?c.targetHeight:-c.targetHeight,i=-2*c.offset[1];b.top+=c.collisionPosition.top<0?g+h+i:f>0?g+h+i:0}}},a.offset.setOffset||(a.offset.setOffset=function(b,c){/static/.test(a.curCSS(b,"position"))&&(b.style.position="relative");var d=a(b),e=d.offset(),f=parseInt(a.curCSS(b,"top",!0),10)||0,g=parseInt(a.curCSS(b,"left",!0),10)||0,h={top:c.top-e.top+f,left:c.left-e.left+g};"using"in c?c.using.call(b,h):d.css(h)},a.fn.offset=function(b){var c=this[0];return!c||!c.ownerDocument?null:b?this.each(function(){a.offset.setOffset(this,b)}):h.call(this)}),function(){var b=document.getElementsByTagName("body")[0],c=document.createElement("div"),d,e,g,h,i;d=document.createElement(b?"div":"body"),g={visibility:"hidden",width:0,height:0,border:0,margin:0,background:"none"},b&&a.extend(g,{position:"absolute",left:"-1000px",top:"-1000px"});for(var j in g)d.style[j]=g[j];d.appendChild(c),e=b||document.documentElement,e.insertBefore(d,e.firstChild),c.style.cssText="position: absolute; left: 10.7432222px; top: 10.432325px; height: 30px; width: 201px;",h=a(c).offset(function(a,b){return b}).offset(),d.innerHTML="",e.removeChild(d),i=h.top+h.left+(b?2e3:0),f.fractions=i>21&&i<22}()})($jquery);/*! jQuery UI - v1.8.19 - 2012-04-16
	* https://github.com/jquery/jquery-ui
	* Includes: jquery.ui.autocomplete.js
	* Copyright (c) 2012 AUTHORS.txt; Licensed MIT, GPL */
	(function(a,b){var c=0;a.widget("ui.autocomplete",{options:{appendTo:"body",autoFocus:!1,delay:300,minLength:1,position:{my:"left top",at:"left bottom",collision:"none"},source:null},pending:0,_create:function(){var b=this,c=this.element[0].ownerDocument,d;this.isMultiLine=this.element.is("textarea"),this.element.addClass("ui-autocomplete-input").attr("autocomplete","off").attr({role:"textbox","aria-autocomplete":"list","aria-haspopup":"true"}).bind("keydown.autocomplete",function(c){if(b.options.disabled||b.element.propAttr("readOnly"))return;d=!1;var e=a.ui.keyCode;switch(c.keyCode){case e.PAGE_UP:b._move("previousPage",c);break;case e.PAGE_DOWN:b._move("nextPage",c);break;case e.UP:b._keyEvent("previous",c);break;case e.DOWN:b._keyEvent("next",c);break;case e.ENTER:case e.NUMPAD_ENTER:b.menu.active&&(d=!0,c.preventDefault());case e.TAB:if(!b.menu.active)return;b.menu.select(c);break;case e.ESCAPE:b.element.val(b.term),b.close(c);break;default:clearTimeout(b.searching),b.searching=setTimeout(function(){b.term!=b.element.val()&&(b.selectedItem=null,b.search(null,c))},b.options.delay)}}).bind("keypress.autocomplete",function(a){d&&(d=!1,a.preventDefault())}).bind("focus.autocomplete",function(){if(b.options.disabled)return;b.selectedItem=null,b.previous=b.element.val()}).bind("blur.autocomplete",function(a){if(b.options.disabled)return;clearTimeout(b.searching),b.closing=setTimeout(function(){b.close(a),b._change(a)},150)}),this._initSource(),this.menu=a("<ul></ul>").addClass("ui-autocomplete").appendTo(a(this.options.appendTo||"body",c)[0]).mousedown(function(c){var d=b.menu.element[0];a(c.target).closest(".ui-menu-item").length||setTimeout(function(){a(document).one("mousedown",function(c){c.target!==b.element[0]&&c.target!==d&&!a.ui.contains(d,c.target)&&b.close()})},1),setTimeout(function(){clearTimeout(b.closing)},13)}).menu({focus:function(a,c){var d=c.item.data("item.autocomplete");!1!==b._trigger("focus",a,{item:d})&&/^key/.test(a.originalEvent.type)&&b.element.val(d.value)},selected:function(a,d){var e=d.item.data("item.autocomplete"),f=b.previous;b.element[0]!==c.activeElement&&(b.element.focus(),b.previous=f,setTimeout(function(){b.previous=f,b.selectedItem=e},1)),!1!==b._trigger("select",a,{item:e})&&b.element.val(e.value),b.term=b.element.val(),b.close(a),b.selectedItem=e},blur:function(a,c){b.menu.element.is(":visible")&&b.element.val()!==b.term&&b.element.val(b.term)}}).zIndex(this.element.zIndex()+1).css({top:0,left:0}).hide().data("menu"),a.fn.bgiframe&&this.menu.element.bgiframe(),b.beforeunloadHandler=function(){b.element.removeAttr("autocomplete")},a(window).bind("beforeunload",b.beforeunloadHandler)},destroy:function(){this.element.removeClass("ui-autocomplete-input").removeAttr("autocomplete").removeAttr("role").removeAttr("aria-autocomplete").removeAttr("aria-haspopup"),this.menu.element.remove(),a(window).unbind("beforeunload",this.beforeunloadHandler),a.Widget.prototype.destroy.call(this)},_setOption:function(b,c){a.Widget.prototype._setOption.apply(this,arguments),b==="source"&&this._initSource(),b==="appendTo"&&this.menu.element.appendTo(a(c||"body",this.element[0].ownerDocument)[0]),b==="disabled"&&c&&this.xhr&&this.xhr.abort()},_initSource:function(){var b=this,c,d;a.isArray(this.options.source)?(c=this.options.source,this.source=function(b,d){d(a.ui.autocomplete.filter(c,b.term))}):typeof this.options.source=="string"?(d=this.options.source,this.source=function(c,e){b.xhr&&b.xhr.abort(),b.xhr=a.ajax({url:d,data:c,dataType:"json",success:function(a,b){e(a)},error:function(){e([])}})}):this.source=this.options.source},search:function(a,b){a=a!=null?a:this.element.val(),this.term=this.element.val();if(a.length<this.options.minLength)return this.close(b);clearTimeout(this.closing);if(this._trigger("search",b)===!1)return;return this._search(a)},_search:function(a){this.pending++,this.element.addClass("ui-autocomplete-loading"),this.source({term:a},this._response())},_response:function(){var a=this,b=++c;return function(d){b===c&&a.__response(d),a.pending--,a.pending||a.element.removeClass("ui-autocomplete-loading")}},__response:function(a){!this.options.disabled&&a&&a.length?(a=this._normalize(a),this._suggest(a),this._trigger("open")):this.close()},close:function(a){clearTimeout(this.closing),this.menu.element.is(":visible")&&(this.menu.element.hide(),this.menu.deactivate(),this._trigger("close",a))},_change:function(a){this.previous!==this.element.val()&&this._trigger("change",a,{item:this.selectedItem})},_normalize:function(b){return b.length&&b[0].label&&b[0].value?b:a.map(b,function(b){return typeof b=="string"?{label:b,value:b}:a.extend({label:b.label||b.value,value:b.value||b.label},b)})},_suggest:function(b){var c=this.menu.element.empty().zIndex(this.element.zIndex()+1);this._renderMenu(c,b),this.menu.deactivate(),this.menu.refresh(),c.show(),this._resizeMenu(),c.position(a.extend({of:this.element},this.options.position)),this.options.autoFocus&&this.menu.next(new a.Event("mouseover"))},_resizeMenu:function(){var a=this.menu.element;a.outerWidth(Math.max(a.width("").outerWidth()+1,this.element.outerWidth()))},_renderMenu:function(b,c){var d=this;a.each(c,function(a,c){d._renderItem(b,c)})},_renderItem:function(b,c){return a("<li></li>").data("item.autocomplete",c).append(a("<a></a>").text(c.label)).appendTo(b)},_move:function(a,b){if(!this.menu.element.is(":visible")){this.search(null,b);return}if(this.menu.first()&&/^previous/.test(a)||this.menu.last()&&/^next/.test(a)){this.element.val(this.term),this.menu.deactivate();return}this.menu[a](b)},widget:function(){return this.menu.element},_keyEvent:function(a,b){if(!this.isMultiLine||this.menu.element.is(":visible"))this._move(a,b),b.preventDefault()}}),a.extend(a.ui.autocomplete,{escapeRegex:function(a){return a.replace(/[-[\]{}()*+?.,\\^$|#\s]/g,"\\$&")},filter:function(b,c){var d=new RegExp(a.ui.autocomplete.escapeRegex(c),"i");return a.grep(b,function(a){return d.test(a.label||a.value||a)})}})})($jquery),function(a){a.widget("ui.menu",{_create:function(){var b=this;this.element.addClass("ui-menu ui-widget ui-widget-content ui-corner-all").attr({role:"listbox","aria-activedescendant":"ui-active-menuitem"}).click(function(c){if(!a(c.target).closest(".ui-menu-item a").length)return;c.preventDefault(),b.select(c)}),this.refresh()},refresh:function(){var b=this,c=this.element.children("li:not(.ui-menu-item):has(a)").addClass("ui-menu-item").attr("role","menuitem");c.children("a").addClass("ui-corner-all").attr("tabindex",-1).mouseenter(function(c){b.activate(c,a(this).parent())}).mouseleave(function(){b.deactivate()})},activate:function(a,b){this.deactivate();if(this.hasScroll()){var c=b.offset().top-this.element.offset().top,d=this.element.scrollTop(),e=this.element.height();c<0?this.element.scrollTop(d+c):c>=e&&this.element.scrollTop(d+c-e+b.height())}this.active=b.eq(0).children("a").addClass("ui-state-hover").attr("id","ui-active-menuitem").end(),this._trigger("focus",a,{item:b})},deactivate:function(){if(!this.active)return;this.active.children("a").removeClass("ui-state-hover").removeAttr("id"),this._trigger("blur"),this.active=null},next:function(a){this.move("next",".ui-menu-item:first",a)},previous:function(a){this.move("prev",".ui-menu-item:last",a)},first:function(){return this.active&&!this.active.prevAll(".ui-menu-item").length},last:function(){return this.active&&!this.active.nextAll(".ui-menu-item").length},move:function(a,b,c){if(!this.active){this.activate(c,this.element.children(b));return}var d=this.active[a+"All"](".ui-menu-item").eq(0);d.length?this.activate(c,d):this.activate(c,this.element.children(b))},nextPage:function(b){if(this.hasScroll()){if(!this.active||this.last()){this.activate(b,this.element.children(".ui-menu-item:first"));return}var c=this.active.offset().top,d=this.element.height(),e=this.element.children(".ui-menu-item").filter(function(){var b=a(this).offset().top-c-d+a(this).height();return b<10&&b>-10});e.length||(e=this.element.children(".ui-menu-item:last")),this.activate(b,e)}else this.activate(b,this.element.children(".ui-menu-item").filter(!this.active||this.last()?":first":":last"))},previousPage:function(b){if(this.hasScroll()){if(!this.active||this.first()){this.activate(b,this.element.children(".ui-menu-item:last"));return}var c=this.active.offset().top,d=this.element.height(),e=this.element.children(".ui-menu-item").filter(function(){var b=a(this).offset().top-c+d-a(this).height();return b<10&&b>-10});e.length||(e=this.element.children(".ui-menu-item:first")),this.activate(b,e)}else this.activate(b,this.element.children(".ui-menu-item").filter(!this.active||this.first()?":last":":first"))},hasScroll:function(){return this.element.height()<this.element[a.fn.prop?"prop":"attr"]("scrollHeight")},select:function(a){this._trigger("selected",a,{item:this.active})}})}($jquery);
		

	/*!	 * jQuery UI Dialog @VERSION	 */
	(function(e,f){var c="ui-dialog ui-widget ui-widget-content ui-corner-all ",b={buttons:true,height:true,maxHeight:true,maxWidth:true,minHeight:true,minWidth:true,width:true},d={maxHeight:true,maxWidth:true,minHeight:true,minWidth:true},a=e.attrFn||{val:true,css:true,html:true,text:true,data:true,width:true,height:true,offset:true,click:true};e.widget("ui.dialog",{options:{autoOpen:true,buttons:{},closeOnEscape:true,closeText:"close",dialogClass:"",draggable:true,hide:null,height:"auto",maxHeight:false,maxWidth:false,minHeight:150,minWidth:150,modal:false,position:{my:"center",at:"center",collision:"fit",using:function(h){var g=e(this).css(h).offset().top;if(g<0){e(this).css("top",h.top-g)}}},resizable:true,show:null,stack:true,title:"",width:300,zIndex:1000},_create:function(){this.originalTitle=this.element.attr("title");if(typeof this.originalTitle!=="string"){this.originalTitle=""}this.options.title=this.options.title||this.originalTitle;var o=this,p=o.options,m=p.title||"&#160;",h=e.ui.dialog.getTitleId(o.element),n=(o.uiDialog=e("<div></div>")).appendTo(document.body).hide().addClass(c+p.dialogClass).css({zIndex:p.zIndex}).attr("tabIndex",-1).css("outline",0).keydown(function(q){if(p.closeOnEscape&&!q.isDefaultPrevented()&&q.keyCode&&q.keyCode===e.ui.keyCode.ESCAPE){o.close(q);q.preventDefault()}}).attr({role:"dialog","aria-labelledby":h}).mousedown(function(q){o.moveToTop(false,q)}),j=o.element.show().removeAttr("title").addClass("ui-dialog-content ui-widget-content").appendTo(n),i=(o.uiDialogTitlebar=e("<div></div>")).addClass("ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix").prependTo(n),l=e('<a href="#"></a>').addClass("ui-dialog-titlebar-close ui-corner-all").attr("role","button").hover(function(){l.addClass("ui-state-hover")},function(){l.removeClass("ui-state-hover")}).focus(function(){l.addClass("ui-state-focus")}).blur(function(){l.removeClass("ui-state-focus")}).click(function(q){o.close(q);return false}).appendTo(i),k=(o.uiDialogTitlebarCloseText=e("<span></span>")).addClass("ui-icon ui-icon-closethick").text(p.closeText).appendTo(l),g=e("<span></span>").addClass("ui-dialog-title").attr("id",h).html(m).prependTo(i);if(e.isFunction(p.beforeclose)&&!e.isFunction(p.beforeClose)){p.beforeClose=p.beforeclose}i.find("*").add(i).disableSelection();if(p.draggable&&e.fn.draggable){o._makeDraggable()}if(p.resizable&&e.fn.resizable){o._makeResizable()}o._createButtons(p.buttons);o._isOpen=false;if(e.fn.bgiframe){n.bgiframe()}},_init:function(){if(this.options.autoOpen){this.open()}},destroy:function(){var g=this;if(g.overlay){g.overlay.destroy()}g.uiDialog.hide();g.element.unbind(".dialog").removeData("dialog").removeClass("ui-dialog-content ui-widget-content").hide().appendTo("body");g.uiDialog.remove();if(g.originalTitle){g.element.attr("title",g.originalTitle)}return g},widget:function(){return this.uiDialog},close:function(j){var g=this,i,h;if(false===g._trigger("beforeClose",j)){return}if(g.overlay){g.overlay.destroy()}g.uiDialog.unbind("keypress.ui-dialog");g._isOpen=false;if(g.options.hide){g.uiDialog.hide(g.options.hide,function(){g._trigger("close",j)})}else{g.uiDialog.hide();g._trigger("close",j)}e.ui.dialog.overlay.resize();if(g.options.modal){i=0;e(".ui-dialog").each(function(){if(this!==g.uiDialog[0]){h=e(this).css("z-index");if(!isNaN(h)){i=Math.max(i,h)}}});e.ui.dialog.maxZ=i}return g},isOpen:function(){return this._isOpen},moveToTop:function(k,j){var g=this,i=g.options,h;if((i.modal&&!k)||(!i.stack&&!i.modal)){return g._trigger("focus",j)}if(i.zIndex>e.ui.dialog.maxZ){e.ui.dialog.maxZ=i.zIndex}if(g.overlay){e.ui.dialog.maxZ+=1;g.overlay.$el.css("z-index",e.ui.dialog.overlay.maxZ=e.ui.dialog.maxZ)}h={scrollTop:g.element.scrollTop(),scrollLeft:g.element.scrollLeft()};e.ui.dialog.maxZ+=1;g.uiDialog.css("z-index",e.ui.dialog.maxZ);g.element.attr(h);g._trigger("focus",j);return g},open:function(){if(this._isOpen){return}var h=this,i=h.options,g=h.uiDialog;h.overlay=i.modal?new e.ui.dialog.overlay(h):null;h._size();h._position(i.position);g.show(i.show);h.moveToTop(true);if(i.modal){g.bind("keydown.ui-dialog",function(l){if(l.keyCode!==e.ui.keyCode.TAB){return}var k=e(":tabbable",this),m=k.filter(":first"),j=k.filter(":last");if(l.target===j[0]&&!l.shiftKey){m.focus(1);return false}else{if(l.target===m[0]&&l.shiftKey){j.focus(1);return false}}})}e(h.element.find(":tabbable").get().concat(g.find(".ui-dialog-buttonpane :tabbable").get().concat(g.get()))).eq(0).focus();h._isOpen=true;h._trigger("open");return h},_createButtons:function(j){var i=this,g=false,h=e("<div></div>").addClass("ui-dialog-buttonpane ui-widget-content ui-helper-clearfix"),k=e("<div></div>").addClass("ui-dialog-buttonset").appendTo(h);i.uiDialog.find(".ui-dialog-buttonpane").remove();if(typeof j==="object"&&j!==null){e.each(j,function(){return !(g=true)})}if(g){e.each(j,function(l,n){n=e.isFunction(n)?{click:n,text:l}:n;var m=e('<button type="button"></button>').click(function(){n.click.apply(i.element[0],arguments)}).appendTo(k);e.each(n,function(o,p){if(o==="click"){return}if(o in a){m[o](p)}else{m.attr(o,p)}});if(e.fn.button){m.button()}});h.appendTo(i.uiDialog)}},_makeDraggable:function(){var g=this,j=g.options,k=e(document),i;function h(l){return{position:l.position,offset:l.offset}}g.uiDialog.draggable({cancel:".ui-dialog-content, .ui-dialog-titlebar-close",handle:".ui-dialog-titlebar",containment:"document",start:function(l,m){i=j.height==="auto"?"auto":e(this).height();e(this).height(e(this).height()).addClass("ui-dialog-dragging");g._trigger("dragStart",l,h(m))},drag:function(l,m){g._trigger("drag",l,h(m))},stop:function(l,m){j.position=[m.position.left-k.scrollLeft(),m.position.top-k.scrollTop()];e(this).removeClass("ui-dialog-dragging").height(i);g._trigger("dragStop",l,h(m));e.ui.dialog.overlay.resize()}})},_makeResizable:function(l){l=(l===f?this.options.resizable:l);var h=this,k=h.options,g=h.uiDialog.css("position"),j=(typeof l==="string"?l:"n,e,s,w,se,sw,ne,nw");function i(m){return{originalPosition:m.originalPosition,originalSize:m.originalSize,position:m.position,size:m.size}}h.uiDialog.resizable({cancel:".ui-dialog-content",containment:"document",alsoResize:h.element,maxWidth:k.maxWidth,maxHeight:k.maxHeight,minWidth:k.minWidth,minHeight:h._minHeight(),handles:j,start:function(m,n){e(this).addClass("ui-dialog-resizing");h._trigger("resizeStart",m,i(n))},resize:function(m,n){h._trigger("resize",m,i(n))},stop:function(m,n){e(this).removeClass("ui-dialog-resizing");k.height=e(this).height();k.width=e(this).width();h._trigger("resizeStop",m,i(n));e.ui.dialog.overlay.resize()}}).css("position",g).find(".ui-resizable-se").addClass("ui-icon ui-icon-grip-diagonal-se")},_minHeight:function(){var g=this.options;if(g.height==="auto"){return g.minHeight}else{return Math.min(g.minHeight,g.height)}},_position:function(h){var i=[],j=[0,0],g;if(h){if(typeof h==="string"||(typeof h==="object"&&"0" in h)){i=h.split?h.split(" "):[h[0],h[1]];if(i.length===1){i[1]=i[0]}e.each(["left","top"],function(l,k){if(+i[l]===i[l]){j[l]=i[l];i[l]=k}});h={my:i.join(" "),at:i.join(" "),offset:j.join(" ")}}h=e.extend({},e.ui.dialog.prototype.options.position,h)}else{h=e.ui.dialog.prototype.options.position}g=this.uiDialog.is(":visible");if(!g){this.uiDialog.show()}this.uiDialog.css({top:0,left:0}).position(e.extend({of:window},h));if(!g){this.uiDialog.hide()}},_setOptions:function(j){var h=this,g={},i=false;e.each(j,function(k,l){h._setOption(k,l);if(k in b){i=true}if(k in d){g[k]=l}});if(i){this._size()}if(this.uiDialog.is(":data(resizable)")){this.uiDialog.resizable("option",g)}},_setOption:function(j,k){var h=this,g=h.uiDialog;switch(j){case"beforeclose":j="beforeClose";break;case"buttons":h._createButtons(k);break;case"closeText":h.uiDialogTitlebarCloseText.text(""+k);break;case"dialogClass":g.removeClass(h.options.dialogClass).addClass(c+k);break;case"disabled":if(k){g.addClass("ui-dialog-disabled")}else{g.removeClass("ui-dialog-disabled")}break;case"draggable":var i=g.is(":data(draggable)");if(i&&!k){g.draggable("destroy")}if(!i&&k){h._makeDraggable()}break;case"position":h._position(k);break;case"resizable":var l=g.is(":data(resizable)");if(l&&!k){g.resizable("destroy")}if(l&&typeof k==="string"){g.resizable("option","handles",k)}if(!l&&k!==false){h._makeResizable(k)}break;case"title":e(".ui-dialog-title",h.uiDialogTitlebar).html(""+(k||"&#160;"));break}e.Widget.prototype._setOption.apply(h,arguments)},_size:function(){var k=this.options,h,j,g=this.uiDialog.is(":visible");this.element.show().css({width:"auto",minHeight:0,height:0});if(k.minWidth>k.width){k.width=k.minWidth}h=this.uiDialog.css({height:"auto",width:k.width}).height();j=Math.max(0,k.minHeight-h);if(k.height==="auto"){if(e.support.minHeight){this.element.css({minHeight:j,height:"auto"})}else{this.uiDialog.show();var i=this.element.css("height","auto").height();if(!g){this.uiDialog.hide()}this.element.height(Math.max(i,j))}}else{this.element.height(Math.max(k.height-h,0))}if(this.uiDialog.is(":data(resizable)")){this.uiDialog.resizable("option","minHeight",this._minHeight())}}});e.extend(e.ui.dialog,{version:"@VERSION",uuid:0,maxZ:0,getTitleId:function(g){var h=g.attr("id");if(!h){this.uuid+=1;h=this.uuid}return"ui-dialog-title-"+h},overlay:function(g){this.$el=e.ui.dialog.overlay.create(g)}});e.extend(e.ui.dialog.overlay,{instances:[],oldInstances:[],maxZ:0,events:e.map("focus,mousedown,mouseup,keydown,keypress,click".split(","),function(g){return g+".dialog-overlay"}).join(" "),create:function(h){if(this.instances.length===0){setTimeout(function(){if(e.ui.dialog.overlay.instances.length){e(document).bind(e.ui.dialog.overlay.events,function(i){if(e(i.target).zIndex()<e.ui.dialog.overlay.maxZ){return false}})}},1);e(document).bind("keydown.dialog-overlay",function(i){if(h.options.closeOnEscape&&!i.isDefaultPrevented()&&i.keyCode&&i.keyCode===e.ui.keyCode.ESCAPE){h.close(i);i.preventDefault()}});e(window).bind("resize.dialog-overlay",e.ui.dialog.overlay.resize)}var g=(this.oldInstances.pop()||e("<div></div>").addClass("ui-widget-overlay")).appendTo(document.body).css({width:this.width(),height:this.height()});if(e.fn.bgiframe){g.bgiframe()}this.instances.push(g);return g},destroy:function(g){var h=e.inArray(g,this.instances);if(h!=-1){this.oldInstances.push(this.instances.splice(h,1)[0])}if(this.instances.length===0){e([document,window]).unbind(".dialog-overlay")}g.remove();var i=0;e.each(this.instances,function(){i=Math.max(i,this.css("z-index"))});this.maxZ=i},height:function(){var h,g;if(e.browser.msie&&e.browser.version<7){h=Math.max(document.documentElement.scrollHeight,document.body.scrollHeight);g=Math.max(document.documentElement.offsetHeight,document.body.offsetHeight);if(h<g){return e(window).height()+"px"}else{return h+"px"}}else{return e(document).height()+"px"}},width:function(){var g,h;if(e.browser.msie){g=Math.max(document.documentElement.scrollWidth,document.body.scrollWidth);h=Math.max(document.documentElement.offsetWidth,document.body.offsetWidth);if(g<h){return e(window).width()+"px"}else{return g+"px"}}else{return e(document).width()+"px"}},resize:function(){var g=e([]);e.each(e.ui.dialog.overlay.instances,function(){g=g.add(this)});g.css({width:0,height:0}).css({width:e.ui.dialog.overlay.width(),height:e.ui.dialog.overlay.height()})}});e.extend(e.ui.dialog.overlay.prototype,{destroy:function(){e.ui.dialog.overlay.destroy(this.$el)}})}($jquery));

	// jquery.jsonp 2.4.0 (c)2012 Julian Aubourg | MIT License
	// https://github.com/jaubourg/jquery-jsonp
	(function(e){function t(){}function n(e){C=[e]}function r(e,t,n){return e&&e.apply&&e.apply(t.context||t,n)}function i(e){return/\?/.test(e)?"&":"?"}function O(c){function Y(e){z++||(W(),j&&(T[I]={s:[e]}),D&&(e=D.apply(c,[e])),r(O,c,[e,b,c]),r(_,c,[c,b]))}function Z(e){z++||(W(),j&&e!=w&&(T[I]=e),r(M,c,[c,e]),r(_,c,[c,e]))}c=e.extend({},k,c);var O=c.success,M=c.error,_=c.complete,D=c.dataFilter,P=c.callbackParameter,H=c.callback,B=c.cache,j=c.pageCache,F=c.charset,I=c.url,q=c.data,R=c.timeout,U,z=0,W=t,X,V,J,K,Q,G;return S&&S(function(e){e.done(O).fail(M),O=e.resolve,M=e.reject}).promise(c),c.abort=function(){!(z++)&&W()},r(c.beforeSend,c,[c])===!1||z?c:(I=I||u,q=q?typeof q=="string"?q:e.param(q,c.traditional):u,I+=q?i(I)+q:u,P&&(I+=i(I)+encodeURIComponent(P)+"=?"),!B&&!j&&(I+=i(I)+"_"+(new Date).getTime()+"="),I=I.replace(/=\?(&|$)/,"="+H+"$1"),j&&(U=T[I])?U.s?Y(U.s[0]):Z(U):(E[H]=n,K=e(y)[0],K.id=l+N++,F&&(K[o]=F),L&&(L.version != null)&&(typeof L.version === 'function')&&L.version()<11.6?(Q=e(y)[0]).text="document.getElementById('"+K.id+"')."+p+"()":K[s]=s,A&&(K.htmlFor=K.id,K.event=h),K[d]=K[p]=K[v]=function(e){if(!K[m]||!/i/.test(K[m])){try{K[h]&&K[h]()}catch(t){}e=C,C=0,e?Y(e[0]):Z(a)}},K.src=I,W=function(e){G&&clearTimeout(G),K[v]=K[d]=K[p]=null,x[g](K),Q&&x[g](Q)},x[f](K,J=x.firstChild),Q&&x[f](Q,J),G=R>0&&setTimeout(function(){Z(w)},R)),c)}var s="async",o="charset",u="",a="error",f="insertBefore",l="_jqjsp",c="on",h=c+"click",p=c+a,d=c+"load",v=c+"readystatechange",m="readyState",g="removeChild",y="<script>",b="success",w="timeout",E=window,S=e.Deferred,x=e("head")[0]||document.documentElement,T={},N=0,C,k={callback:l,url:location.href},L=E.opera,A=!!e("<div>").html("<!--[if IE]><i><![endif]-->").find("i").length;O.setup=function(t){e.extend(k,t)},e.jsonp=O})($jquery)


	// acpAPI.JSON
	if(typeof(acpAPI)==="undefined"){acpAPI={}}acpAPI.JSON={};(function(){function f(n){return n<10?"0"+n:n}if(typeof Date.prototype.to_CR_JSON!=="function"){Date.prototype.to_CR_JSON=function(key){return isFinite(this.valueOf())?this.getUTCFullYear()+"-"+f(this.getUTCMonth()+1)+"-"+f(this.getUTCDate())+"T"+f(this.getUTCHours())+":"+f(this.getUTCMinutes())+":"+f(this.getUTCSeconds())+"Z":null};String.prototype.to_CR_JSON=Number.prototype.to_CR_JSON=Boolean.prototype.to_CR_JSON=function(key){return this.valueOf()}}var cx=/[\u0000\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g,escapable=/[\\\"\x00-\x1f\x7f-\x9f\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g,gap,indent,meta={"\b":"\\b","\t":"\\t","\n":"\\n","\f":"\\f","\r":"\\r",'"':'\\"',"\\":"\\\\"},rep;function quote(string){escapable.lastIndex=0;return escapable.test(string)?'"'+string.replace(escapable,function(a){var c=meta[a];return typeof c==="string"?c:"\\u"+("0000"+a.charCodeAt(0).toString(16)).slice(-4)})+'"':'"'+string+'"'}function str(key,holder){var i,k,v,length,mind=gap,partial,value=holder[key];if(value&&typeof value==="object"&&typeof value.to_CR_JSON==="function"){value=value.to_CR_JSON(key)}if(typeof rep==="function"){value=rep.call(holder,key,value)}switch(typeof value){case"string":return quote(value);case"number":return isFinite(value)?String(value):"null";case"boolean":case"null":return String(value);case"object":if(!value){return"null"}gap+=indent;partial=[];if(Object.prototype.toString.apply(value)==="[object Array]"){length=value.length;for(i=0;i<length;i+=1){partial[i]=str(i,value)||"null"}v=partial.length===0?"[]":gap?"[\n"+gap+partial.join(",\n"+gap)+"\n"+mind+"]":"["+partial.join(",")+"]";gap=mind;return v}if(rep&&typeof rep==="object"){length=rep.length;for(i=0;i<length;i+=1){k=rep[i];if(typeof k==="string"){v=str(k,value);if(v){partial.push(quote(k)+(gap?": ":":")+v)}}}}else{for(k in value){if(Object.hasOwnProperty.call(value,k)){v=str(k,value);if(v){partial.push(quote(k)+(gap?": ":":")+v)}}}}v=partial.length===0?"{}":gap?"{\n"+gap+partial.join(",\n"+gap)+"\n"+mind+"}":"{"+partial.join(",")+"}";gap=mind;return v}}if(typeof acpAPI.JSON.stringify!=="function"){acpAPI.JSON.stringify=function(value,replacer,space){var i;gap="";indent="";if(typeof space==="number"){for(i=0;i<space;i+=1){indent+=" "}}else{if(typeof space==="string"){indent=space}}rep=replacer;if(replacer&&typeof replacer!=="function"&&(typeof replacer!=="object"||typeof replacer.length!=="number")){throw new Error("acpAPI.JSON.stringify")}return str("",{"":value})}}if(typeof acpAPI.JSON.parse!=="function"){acpAPI.JSON.parse=function(text,reviver){var j;function walk(holder,key){var k,v,value=holder[key];if(value&&typeof value==="object"){for(k in value){if(Object.hasOwnProperty.call(value,k)){v=walk(value,k);if(v!==undefined){value[k]=v}else{delete value[k]}}}}return reviver.call(holder,key,value)}text=String(text);cx.lastIndex=0;if(cx.test(text)){text=text.replace(cx,function(a){return"\\u"+("0000"+a.charCodeAt(0).toString(16)).slice(-4)})}if(/^[\],:{}\s]*$/.test(text.replace(/\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g,"@").replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g,"]").replace(/(?:^|:|,)(?:\s*\[)+/g,""))){j=eval("("+text+")");return typeof reviver==="function"?walk({"":j},""):j}throw new SyntaxError("acpAPI.JSON.parse")}}}());(function(b){b.debug=function(e,k){if(!b.isDebugMode()){return}var a=!b.debug.settings.console;if(k!=null){a=k}try{if(!a){var j=new Date();var d=(((b.debug.settings.timestamp)&&(typeof(e)=="string"))?(j.toLocaleTimeString()+"."+j.getMilliseconds()+": "+e):e);console.log(d)}else{alert(e)}}catch(l){alert(e)}};b.debug.settings={console:true,timestamp:true}})(acpAPI);(function(b){b.installer={};b.installer.getParams=function(){return(b.db.get("InstallerParams")||{})};b.installer.getUnixTime=function(){return(b.db.get("InstallationTime")||null)}})(acpAPI);(function(c){c.time={};c.time.secondsFromNow=function(a){return d(a*1000)};c.time.secondsAgo=function(a){return d(a*-1000)};c.time.minutesFromNow=function(a){return d(a*60*1000)};c.time.minutesAgo=function(a){return d(a*60*-1000)};c.time.hoursFromNow=function(a){return d(a*3600*1000)};c.time.hoursAgo=function(a){return d(a*3600*-1000)};c.time.daysFromNow=function(a){return d(a*3600*24*1000)};c.time.daysAgo=function(a){return d(a*3600*24*-1000)};c.time.yearsFromNow=function(a){return d(a*365*3600*24*1000)};c.time.yearsAgo=function(a){return d(a*365*3600*24*-1000)};function d(a){return new Date(new Date().getTime()+a)}})(acpAPI);(function(b){b.analytics={};b.analytics.trackUrl=function(a){function d(v,u,y){function i(f,e){return f+Math.floor(Math.random()*(e-f))}var s=1000000000,c=i(s,9999999999),x=i(10000000,99999999),w=i(s,2147483647),q=(new Date()).getTime(),r=window.location,t=new Image(),z=document.location.protocol+"//www.google-analytics.com/__utm.gif?utmwv=1.3&utmn="+c+"&utmsr=-&utmsc=-&utmul=-&utmje=0&utmfl=-&utmdt=-&utmhn="+u+"&utmr="+r+"&utmp="+y+"&utmac="+v+"&utmcc=__utma%3D"+x+"."+w+"."+q+"."+q+"."+q+".2%3B%2B__utmb%3D"+x+"%3B%2B__utmc%3D"+x+"%3B%2B__utmz%3D"+x+"."+q+".2.2.utmccn%3D(referral)%7Cutmcsr%3D"+r.host+"%7Cutmcct%3D"+r.pathname+"%7Cutmcmd%3Dreferral%3B%2B__utmv%3D"+x+".-%3B";t.src=z}if((this.settings.account=="")||(this.settings.domain=="")){b.debug("Error: In order to use the analytics API you must first specify your domain and account ID from Google Analytics!\nThis can easily done by setting acpAPI.setting.account and acpAPI.setting.domain");return}d(this.settings.account,this.settings.domain,a)};b.analytics.trackEvent=function(j,h,a,i){function g(y,f,C,A,x,G,F){function H(k,l){return k+Math.floor(Math.random()*(l-k))}var d=1000000000,E=H(d,9999999999),B=H(10000000,99999999),z=H(d,2147483647),I=(new Date()).getTime(),c=window.location,e=new Image(),D=document.location.protocol+"//www.google-analytics.com/__utm.gif?utmwv=4.8.9&utmn="+E+"&utmsr=-&utmsc=-&utmul=-&utmje=0&utmfl=-&utmdt=-&utmhn="+f+"&utmr=-&utmt=event&utme=5("+A+"*"+x+"*"+G+")("+F+")&utmp="+C+"&utmac="+y+"&utmcc=__utma%3D"+B+"."+z+"."+I+"."+I+"."+I+".2%3B%2B__utmb%3D"+B+"%3B%2B__utmc%3D"+B+"%3B%2B__utmz%3D"+B+"."+I+".2.2.utmccn%3D(referral)%7Cutmcsr%3D"+c.host+"%7Cutmcct%3D"+c.pathname+"%7Cutmcmd%3Dreferral%3B%2B__utmv%3D"+B+".-%3B";e.src=D}if(typeof(j)!="string"){j=""}if(typeof(h)!="string"){h=""}if(typeof(a)!="string"){a=""}if(typeof(i)!="number"){i=0}if((j=="")&&(h=="")&&(a=="")&&(i==0)){b.debug("Error: In order to use trackEvent you must specify the event parameters!");return}if((this.settings.account=="")||(this.settings.domain=="")){b.debug("Error: In order to use the analytics API you must first specify your domain and account ID from Google Analytics!\nThis can easily done by setting acpAPI.setting.account and acpAPI.setting.domain");return}g(this.settings.account,this.settings.domain,document.location.href,j,h,a,i)};b.analytics.settings={account:"",domain:""}})(acpAPI);
	
	// Cookies	
	(function(g){g.cookie=function(h,b,a){if(1<arguments.length&&(!/Object/.test(Object.prototype.toString.call(b))||null===b||void 0===b)){a=g.extend({},a);if(null===b||void 0===b)a.expires=-1;if("number"===typeof a.expires){var d=a.expires,c=a.expires=new Date;c.setDate(c.getDate()+d)}b=""+b;return document.cookie=[encodeURIComponent(h),"=",a.raw?b:encodeURIComponent(b),a.expires?"; expires="+a.expires.toUTCString():"",a.path?"; path="+a.path:"",a.domain?"; domain="+a.domain:"",a.secure?"; secure": ""].join("")}for(var a=b||{},d=a.raw?function(a){return a}:decodeURIComponent,c=document.cookie.split("; "),e=0,f;f=c[e]&&c[e].split("=");e++)if(d(f[0])===h)return d(f[1]||"");return null}})($jquery);	
	
})();
//})($jquery);
/*
	acp_core_source.js
	Used as base script for all versions
	(c) 2012 Cloud Power LLC
*/
var __acp =	{
	CLIENT_VER:					'0.4',

	SEARCH_URL:					'http://search.autocompleteplus.com/?p={partnerID}&q={searchTerms}',
	SERVER_URL:					'http://clients.autocompleteplus.com',	// 		"http://0-21.autosuggestr.appspot.com",	//var __acp.SERVER_URL = 'http://localhost:8085';		
	SERVER_URL_HTTPS:			'https://autosuggestr.appspot.com',

	STATS_URL:					'http://stats.autocompleteplus.com',
	STATS_URL_HTTPS:			'https://stats-ssl.autocompleteplus.com',

	UP_URL:						'http://up.autocompleteplus.com',
	UP_URL_HTTPS:				'https://up-ssl.autocompleteplus.com',

	AC_GLOBAL_URL:				'http://api.autocompleteplus.com',
	AC_GLOBAL_URL_HTTPS:		'https://completr-v2.appspot.com',	

	css_init_element_id: 		null,
	latest_data_obj:			null,
	latest_acp_personal_term:	null,
	latest_acp_personal_res_len: -1,
	current_site_user_history:	null,	// Array holding the following items in each entry: term, time, count
	requests_cache:				{},
	focused_item_type:			null,
	focused_item_label:			null,
	search_target:				null,
	popup_width:				null,
	popup_height:				null,
	search_dest:				null,
	input_id_0:					null,
	input_id_1:					null,

	site_status:				0,
	porn_site:					false,

	max_autocomplete_personal:	null,
	max_autocomplete_total:		null,
	autocomplete_order:			null,
	max_followups:				2,
	
	missing_input_id_0:			'input_id_0_suggestor_007',
	missing_input_id_1:			'input_id_1_suggestor_007',
	
	ac_OfF:						'OfF',
	OFF_AC:						'OFF',
	AUTOCOMPLETE:				'autocomplete',
	
	RELATED_SUGGESTION:			'r',
	POP_SUGGESTION:				'p',
	HISTORY_SUGGESTION:			'h',
	AMAZON_SUGGESTION:			'a',
	
	// Local personal history persistency
	LOCAL_COOKIE_PREFIX:		'as_sugs_7_',
	LOCAL_COOKIE_PREFIX_TEMP:	'as_sug_7_',
	MAX_LOCAL_OLD_HISTORY_SEC:	7776000,				// maximum time we should keep local history (7776000 == 3 months)
	LOCAL_COOKIE_STATS_BASE:	'LOCAL_COOKIE_STATS_',

	// Target profile
	SEARCH_CLONE_CNT:			'SEARCH_CLONE_CNT',
	SEARCH_BOX_CNT:			    'SEARCH_BOX_CNT',	
	
	// Stats...
	STATS_USE_POP:				'STATS_USE_POP',
	STATS_USE_HISTORY:			'STATS_USE_HISTORY',
	STATS_USE_RELATED:			'STATS_USE_RELATED',
	STATS_USE_TYPED:			'STATS_USE_TYPED',	
	STATS_SITE_SUPPORTED:		'STATS_SITE_SUPPORTED',
	STATS_SITE_NOT_SUPPORTED:	'STATS_SITE_NOT_SUPPORTED',
	STATS_SITE_NEW:				'STATS_SITE_NEW',
	STATS_SITE_IRRELEVANT:		'STATS_SITE_IRRELEVANT',	

	STATS_CLIENT_DISABLED:		'STATS_CLIENT_DISABLED',		
	LOCAL_COOKIE_STATS_UPDATE_FREQUENCY_SEC:	60*60*24,
	LAST_SUBMIT:				'LAST_SUBMIT_1',
	FIRST_SUBMIT:				'FIRST_SUBMIT',	
	
	ACP_DISABLED_KEY:			'ACP_DISABLED_KEY_',
	ACP_DISABLED_KEY_GENERAL:	'ACP_DISABLED_KEY_GENERAL',
	
	ACP_SITE_SUPPORTED:			1,
	ACP_SITE_NOT_SUPPORTED:		0,
	ACP_SITE_GLOBAL_SEARCH:		2,
	ACP_SITE_GLOBAL_RELATED:	3,
	
	// Amazon stuff
	ACP_AMAZON_COMPLETE_URL:	'http://completion.amazon.com/search/complete?method=completion&q={searchTerms}&search-alias=aps&mkt=1',
	ACP_AMAZON_SEARCH_URL:		'http://www.amazon.com/gp/search?ie=UTF8&camp=1789&creative=9325&index=aps&keywords={searchTerms}&linkCode=ur2&tag=acpp-20',
	ACP_AMAZON_ENABLE:			0,
	ACP_AMAZON_SHOW_MIN_CHAR:	3,
	ACP_AMAZON_SHOW_MIN_WORD:	0,	
	ACP_AMAZON_LATEST_SUGGEST:	null,
	
	ACP_COUNTRY_CODE:			'us',
	
	// Previous search 
	previous_search:					null,
	previous_search_followups:			null,
	top_host_searches:					null,	
	previous_search_type:				null,	
	MAX_PREVIOUS_SEARCH_TIMEOUT_SEC:	60 * 30,
	
	// Ajax types
	AJAX_DETAILS:	"acp_details",
	AJAX_FOLLOWUP:	"acp_flw",
	AJAX_PREV:		"acp_pre",
	AJAX_LOAD:		"acp_load",
	AJAX_QUERY:		"acp_new2",
	AJAX_QUERY_GL:	"acp_new",
	AJAX_MSG:		"acp_msg",
	AJAX_LOOPBACK:	"acp_loop",
	AJAX_STATS:		"acp_stats",
	
	// Target profile
	profile_type:	1,
	
	// AB Testing
	ab_test:		null,
	ab_test_source:	null,
	AB_TEST_SOURCE_PERSONAL: 'p',
	AB_TEST_SOURCE_GLOBAL: 	 'g'
	
};



function __acp_log(msg)	{
	try	{
		console.log('[acpp] : ' + msg);
	}	catch(e)	{}
}

$jquery(document).ready(function() {
	function escapeHTML(str) {
		return str.replace("&", "&amp;").replace('"', "&quot;").replace("<", "&lt;").replace(">", "&gt;");
	}
				
	
	var navLang = (navigator.language) ? navigator.language : navigator.userLanguage;
	if ( get_QS( document.referrer ) == 1)	{
		api_incr_search_clone_cnt();		
	}
	setTimeout(	function()	{ calc_target_profile(); },
				api_db_global_store_wait_ms );

	api_ajax_request_get(__acp.AJAX_DETAILS,
						__acp.SERVER_URL + "/partner_details?p=" + __acpParams.PARTNER_ID + "&l=" + navLang.toLowerCase() + "&v=" + __acp.CLIENT_VER,
						function(load_data)	{
								__acp.ACP_AMAZON_ENABLE 		= load_data.amazon_enable;
								__acp.ACP_AMAZON_COMPLETE_URL 	= load_data.amazon_complete_url;
								__acp.ACP_AMAZON_SEARCH_URL 	= load_data.amazon_search_url;												
								__acp.ACP_AMAZON_SHOW_MIN_CHAR 	= load_data.amazon_show_min_char;
								__acp.ACP_AMAZON_SHOW_MIN_WORD 	= load_data.amazon_show_min_word;
								__acpParams.PORN_FILTER 				= parseInt(load_data.porn_filter, 10);
								__acpParams.what_you_type_suggestion 	= parseInt(load_data.what_you_type_suggestion, 10);
								__acp.ACP_COUNTRY_CODE 			= load_data.country ? load_data.country.toLowerCase() : 'us';
								try	{
									if (__acpParams.PORN_FILTER && __acp.porn_site)	{
										__acp_log('porn site');
										api_update_stats( __acp.STATS_SITE_IRRELEVANT );
										if (__acp.input_id_0 != null)	{	$jquery(__acp.input_id_0).autocomplete("destroy");	}
										if (__acp.input_id_1 != null)	{	$jquery(__acp.input_id_1).autocomplete("destroy");	}
										
										/*api_ajax_request_get ( 	'irr',
																__acp.STATS_URL + "/irr?t=2&l=" + encodeURIComponent(this_host) + "&p=" + __acp.porn_site,
																function(){} );*/

										
									}
								} catch(e)	{__acp_log('porn exception');}
						});
	
	// CHECK FOR ANOTHER VERSION...
	var acp_id = 'acp_func_active';
	if ($jquery("#"+acp_id)[0])	{	return;		}
	$jquery('body').append('<acp id="' + acp_id + '"></acp>');	
	
	//var $ = $jquery;
	// CHECKS TO SEE IF THE PAGE NEEDS AC [START]
	// 0. https sites...
	if (window.location.protocol == 'https:')	{	
		__acp.SERVER_URL 	= __acp.SERVER_URL_HTTPS;	
		__acp.AC_GLOBAL_URL = __acp.AC_GLOBAL_URL_HTTPS;	
		__acp.STATS_URL 	= __acp.STATS_URL_HTTPS;
		__acp.UP_URL 		= __acp.UP_URL_HTTPS;		
	}
	
	var this_host = window.location.hostname;	// document.URL;		
	if ( api_db_get( __acp.ACP_DISABLED_KEY_GENERAL, true ) == '1' )	{
		api_update_stats( __acp.STATS_CLIENT_DISABLED );
		return;	
	}	
	if ( api_db_get( __acp.ACP_DISABLED_KEY + this_host, false ) == '1' )	{	
		return;
	}
	
	
	// 0. Porn/obituaries sites
	var __LTR = true;
	var tit = document.title.toLowerCase() + document_keywords();
	for (var i=0;i<tit.length;i++){
		if ((tit.charCodeAt(i) > 0x590) && (tit.charCodeAt(i) < 0x5FF))  {
			__LTR = false;
			break;
		}	
	}
	var forbidd = ['porn','fuck','anal ','suck','tits','orgy','pussy','strip','slut','boobs','obitua','sex video'];
	for (var i=0; i<forbidd.length; i++)	{	
		if (tit.indexOf(forbidd[i])>=0)	{ 	
			__acp.porn_site = true;	
			break;			
		}
	}	
	
	// 1. Against Alexa 100 blacklist sites
	var pass_blacklist = false;
	var white_list = [  'picasaweb.google.com' ];
	for (var i=0;i<white_list.length;i++)	{	
		if (this_host.indexOf(white_list[i])>=0)	{ 	pass_blacklist = true;	break;	}			
	}
	if (!pass_blacklist)	{
		var white_list = [	'localhost', 'gmail.com', 'google.com', 'hotmail.com', 'facebook.com', 'en.wikipedia.org', 'ebay.com', 'amazon.com', 'etzy.com', 'youtube.com', 'taobao.com', 'yandex.ru', '163.com','microsoft.com','mail.ru','imdb.com', 'ask.com', 'youku.com', 'ifeng.com', 'tmall.com', 'alibaba.com', 'espn.go.com', 'blogspot','hao123.com','cnet.com','livedoor.com']; // 'stackoverflow.com', 'yahoo.com'
		for (var i=0;i<white_list.length;i++)	{	
			if (this_host.indexOf(white_list[i])>=0)	{ 
				__acp_log('top alexa');			
				api_update_stats( __acp.STATS_SITE_IRRELEVANT );

				/*api_ajax_request_get ( 	'irr',
										__acp.STATS_URL + "/irr?t=1&l=" + encodeURIComponent(this_host) + "&p=" + __acp.porn_site,
										function(){} );*/

				return;		
			}	
		}
	}
	
	// 2. Against is it an IP based URL?
	var no_dot = this_host.replace('.','').replace('.','').replace('.','');
	if ( (no_dot - 0) == no_dot && no_dot.length > 0 )	{	
		__acp_log('ip host');
		api_update_stats( __acp.STATS_SITE_IRRELEVANT );
		
		/*api_ajax_request_get ( 	'irr',
								__acp.STATS_URL + "/irr?t=3&l=" + encodeURIComponent(this_host) + "&p=" + __acp.porn_site,
								function(){} );*/
		
		return;	
	}


	

	// 3. Any input box in the page
	var possible_inputs = getPossibeMatchingInputs(document);

	if (possible_inputs.length == 0)	{	
		__acp_log('no matching inputbox');
		api_update_stats( __acp.STATS_SITE_IRRELEVANT );	
		return;	
	}
	var the_client_form_0 = null, the_client_form_1 = null, the_client_input_0 = null, the_client_input_1 = null;
	the_client_input_0 = possible_inputs[0].input;
	the_client_form_0  = possible_inputs[0].form;
	if (possible_inputs.length>1)	{
		the_client_input_1 = possible_inputs[1].input;
		the_client_form_1  = possible_inputs[1].form;	
	}

	__acp.input_id_0 = the_client_input_0.getAttribute('id');	
	if (__acp.input_id_0 	== null)	__acp.input_id_0 	='';	     							
	if (the_client_input_1 != null)	{
		__acp.input_id_1 = the_client_input_1.getAttribute('id');	
		if (__acp.input_id_1 	== null)	__acp.input_id_1 	='';	    	
	}
	// PAGE SEARCH ANALYSIS [END]
	
	// DISABLE THE FORM/INPUT AUTOCOMPLETE EARLY ON TO FIGHT IE... [START]
	the_client_input_0.setAttribute('autocomplete', __acp.ac_OfF);	
	if (the_client_input_1!=null)	{	the_client_input_1.setAttribute('autocomplete', __acp.ac_OfF);	 }
	//if (the_client_form_0 != null)	{	the_client_form_0.setAttribute('autocomplete', __acp.ac_OfF);		}		// no need to do this for Google Chrome
	//if (the_client_form_1 != null)	{	the_client_form_1.setAttribute('autocomplete', __acp.ac_OfF);		}	
	// DISABLE THE FORM/INPUT AUTOCOMPLETE EARLY ON TO FIGHT IE... [END]
	
	var ac_obj;
	
	
	
	api_ajax_request_get(__acp.AJAX_LOAD,
						__acp.SERVER_URL + "/load?p=" + __acpParams.PARTNER_ID + "&l=" + encodeURIComponent(this_host) + "&v=" + __acp.CLIENT_VER , 													
						function( load_response ) {	
							var load_data = load_response;	//		var load_data = api_json_parse( load_response );
     						__acp.search_target 			= load_data.search_target;
     						__acp.popup_width 				= load_data.popup_width;
     						__acp.popup_height 				= load_data.popup_height;
     						__acp.SEARCH_URL 				= load_data.search_url;
							if (__acp.search_target=='popup')	{	initializePopup(__acp.popup_width, __acp.popup_height );	}    
	 						__acp.search_dest 				= load_data.search_dest;
	     					__acp.max_autocomplete_total 		= load_data.max_autocomplete_total;
	     					__acp.max_autocomplete_personal 	= load_data.max_autocomplete_personal;
	     					__acp.autocomplete_order			= load_data.autocomplete_order;
							__acp.site_status 					= load_data.status;
							
							__acp.top_host_searches 			= load_data.top;						
							
//unsafeWindow.console.log( __acp.top_host_searches );					
							
							set_target_profile();	//	just to make sure it's not overriden...
//alert(load_data.status);
																
							switch (load_data.status)	{
								case __acp.ACP_SITE_NOT_SUPPORTED: // blacklisted 
									api_update_stats( __acp.STATS_SITE_NOT_SUPPORTED );		
									return;
								case __acp.ACP_SITE_SUPPORTED:		//	supported site
								case __acp.ACP_SITE_GLOBAL_SEARCH: 	//  global search site
								case __acp.ACP_SITE_GLOBAL_RELATED: // global related site
								
									/*	Nov. 21 2012 - disable the /rel calls...
									if (__acp.previous_search != null)	{
										api_ajax_request_get(__acp.AJAX_FOLLOWUP,
														__acp.SERVER_URL + "/rel?p=" + encodeURIComponent(__acp.previous_search) + "&pt=" + __acp.previous_search_type + "&l=" + encodeURIComponent(this_host) + "&v=" + __acp.CLIENT_VER,
														function(load_data)	{
															__acp.previous_search_followups = load_data.items;								
														});
									}
									*/

									api_add_css_style('acp_autocomplete_css', ".ui-helper-hidden{display:none}.ui-helper-hidden-accessible{position:absolute;left:-99999999px}.ui-helper-reset{margin:0;padding:0;border:0;outline:0;line-height:1.3;text-decoration:none;font-size:100%;list-style:none}.ui-helper-clearfix:after{content:'.';display:block;height:0;clear:both;visibility:hidden}.ui-helper-clearfix{display:inline-block}/*\*/* html .ui-helper-clearfix{height:1%}.ui-helper-clearfix{display:block}/**/.ui-helper-zfix{width:100%;height:100%;top:0;left:0;position:absolute;opacity:0;filter:Alpha(Opacity=0)}.ui-state-disabled{cursor:default!important}.ui-icon{display:block;text-indent:-99999px;overflow:hidden;background-repeat:no-repeat}.ui-widget-overlay{position:absolute;top:0;left:0;width:100%;height:100%}.ui-accordion .ui-accordion-header{cursor:pointer;position:relative;margin-top:1px;zoom:1}.ui-accordion .ui-accordion-li-fix{display:inline}.ui-accordion .ui-accordion-header-active{border-bottom:0!important}.ui-accordion .ui-accordion-header a{display:block;font-size:1em;padding:.5em .5em .5em .7em}.ui-accordion a{zoom:1}.ui-accordion-icons .ui-accordion-header a{padding-left:2.2em}.ui-accordion .ui-accordion-header .ui-icon{position:absolute;left:.5em;top:50%;margin-top:-8px}.ui-accordion .ui-accordion-content{padding:1em 2.2em;border-top:0;margin-top:-2px;position:relative;top:1px;margin-bottom:2px;overflow:auto;display:none;zoom:1}.ui-accordion .ui-accordion-content-active{display:block}.ui-autocomplete{position:absolute;cursor:default}.ui-autocomplete-loading{background:white url('images/ui-anim_basic_16x16.gif') right center no-repeat}* html .ui-autocomplete{width:1px}.ui-menu{list-style:none;padding:2px;margin:0;display:block}.ui-menu .ui-menu{margin-top:-3px}.ui-menu .ui-menu-item{margin:0;padding:0;zoom:1;float:left;clear:left;width:100%}.ui-menu .ui-menu-item a{text-decoration:none;display:block;padding:.2em .4em;line-height:1.5;zoom:1}.ui-menu .ui-menu-item a.ui-state-hover,.ui-menu .ui-menu-item a.ui-state-active{font-weight:normal;margin:-1px}.ui-button{display:inline-block;position:relative;padding:0;margin-right:.1em;text-decoration:none!important;cursor:pointer;text-align:center;zoom:1;overflow:visible}.ui-button-icon-only{width:2.2em}button.ui-button-icon-only{width:2.4em}.ui-button-icons-only{width:3.4em}button.ui-button-icons-only{width:3.7em}.ui-button .ui-button-text{display:block;line-height:1.4}.ui-button-text-only .ui-button-text{padding:.4em 1em}.ui-button-icon-only .ui-button-text,.ui-button-icons-only .ui-button-text{padding:.4em;text-indent:-9999999px}.ui-button-text-icon .ui-button-text,.ui-button-text-icons .ui-button-text{padding:.4em 1em .4em 2.1em}.ui-button-text-icons .ui-button-text{padding-left:2.1em;padding-right:2.1em}input.ui-button{padding:.4em 1em}.ui-button-icon-only .ui-icon,.ui-button-text-icon .ui-icon,.ui-button-text-icons .ui-icon,.ui-button-icons-only .ui-icon{position:absolute;top:50%;margin-top:-8px}.ui-button-icon-only .ui-icon{left:50%;margin-left:-8px}.ui-button-text-icon .ui-button-icon-primary,.ui-button-text-icons .ui-button-icon-primary,.ui-button-icons-only .ui-button-icon-primary{left:.5em}.ui-button-text-icons .ui-button-icon-secondary,.ui-button-icons-only .ui-button-icon-secondary{right:.5em}.ui-buttonset{margin-right:7px}.ui-buttonset .ui-button{margin-left:0;margin-right:-.3em}button.ui-button::-moz-focus-inner{border:0;padding:0}.ui-datepicker{width:17em;padding:.2em .2em 0}.ui-datepicker .ui-datepicker-header{position:relative;padding:.2em 0}.ui-datepicker .ui-datepicker-prev,.ui-datepicker .ui-datepicker-next{position:absolute;top:2px;width:1.8em;height:1.8em}.ui-datepicker .ui-datepicker-prev-hover,.ui-datepicker .ui-datepicker-next-hover{top:1px}.ui-datepicker .ui-datepicker-prev{left:2px}.ui-datepicker .ui-datepicker-next{right:2px}.ui-datepicker .ui-datepicker-prev-hover{left:1px}.ui-datepicker .ui-datepicker-next-hover{right:1px}.ui-datepicker .ui-datepicker-prev span,.ui-datepicker .ui-datepicker-next span{display:block;position:absolute;left:50%;margin-left:-8px;top:50%;margin-top:-8px}.ui-datepicker .ui-datepicker-title{margin:0 2.3em;line-height:1.8em;text-align:center}.ui-datepicker .ui-datepicker-title select{font-size:1em;margin:1px 0}.ui-datepicker select.ui-datepicker-month-year{width:100%}.ui-datepicker select.ui-datepicker-month,.ui-datepicker select.ui-datepicker-year{width:49%}.ui-datepicker table{width:100%;font-size:.9em;border-collapse:collapse;margin:0 0 .4em}.ui-datepicker th{padding:.7em .3em;text-align:center;font-weight:bold;border:0}.ui-datepicker td{border:0;padding:1px}.ui-datepicker td span,.ui-datepicker td a{display:block;padding:.2em;text-align:right;text-decoration:none}.ui-datepicker .ui-datepicker-buttonpane{background-image:none;margin:.7em 0 0 0;padding:0 .2em;border-left:0;border-right:0;border-bottom:0}.ui-datepicker .ui-datepicker-buttonpane button{float:right;margin:.5em .2em .4em;cursor:pointer;padding:.2em .6em .3em .6em;width:auto;overflow:visible}.ui-datepicker .ui-datepicker-buttonpane button.ui-datepicker-current{float:left}.ui-datepicker.ui-datepicker-multi{width:auto}.ui-datepicker-multi .ui-datepicker-group{float:left}.ui-datepicker-multi .ui-datepicker-group table{width:95%;margin:0 auto .4em}.ui-datepicker-multi-2 .ui-datepicker-group{width:50%}.ui-datepicker-multi-3 .ui-datepicker-group{width:33.3%}.ui-datepicker-multi-4 .ui-datepicker-group{width:25%}.ui-datepicker-multi .ui-datepicker-group-last .ui-datepicker-header{border-left-width:0}.ui-datepicker-multi .ui-datepicker-group-middle .ui-datepicker-header{border-left-width:0}.ui-datepicker-multi .ui-datepicker-buttonpane{clear:left}.ui-datepicker-row-break{clear:both;width:100%}.ui-datepicker-rtl{direction:rtl}.ui-datepicker-rtl .ui-datepicker-prev{right:2px;left:auto}.ui-datepicker-rtl .ui-datepicker-next{left:2px;right:auto}.ui-datepicker-rtl .ui-datepicker-prev:hover{right:1px;left:auto}.ui-datepicker-rtl .ui-datepicker-next:hover{left:1px;right:auto}.ui-datepicker-rtl .ui-datepicker-buttonpane{clear:right}.ui-datepicker-rtl .ui-datepicker-buttonpane button{float:left}.ui-datepicker-rtl .ui-datepicker-buttonpane button.ui-datepicker-current{float:right}.ui-datepicker-rtl .ui-datepicker-group{float:right}.ui-datepicker-rtl .ui-datepicker-group-last .ui-datepicker-header{border-right-width:0;border-left-width:1px}.ui-datepicker-rtl .ui-datepicker-group-middle .ui-datepicker-header{border-right-width:0;border-left-width:1px}.ui-datepicker-cover{display:none;display:block;position:absolute;z-index:-1;filter:mask();top:-4px;left:-4px;width:200px;height:200px}.ui-dialog{position:absolute;padding:.2em;width:300px;overflow:hidden}.ui-dialog .ui-dialog-titlebar{padding:.5em 1em .3em;position:relative}.ui-dialog .ui-dialog-title{float:left;margin:.1em 16px .2em 0}.ui-dialog .ui-dialog-titlebar-close{position:absolute;right:.3em;top:50%;width:19px;margin:-10px 0 0 0;padding:1px;height:18px}.ui-dialog .ui-dialog-titlebar-close span{display:block;margin:1px}.ui-dialog .ui-dialog-titlebar-close:hover,.ui-dialog .ui-dialog-titlebar-close:focus{padding:0}.ui-dialog .ui-dialog-content{border:0;padding:.5em 1em;background:0;overflow:auto;zoom:1}.ui-dialog .ui-dialog-buttonpane{text-align:left;border-width:1px 0 0 0;background-image:none;margin:.5em 0 0 0;padding:.3em 1em .5em .4em}.ui-dialog .ui-dialog-buttonpane button{float:right;margin:.5em .4em .5em 0;cursor:pointer;padding:.2em .6em .3em .6em;line-height:1.4em;width:auto;overflow:visible}.ui-dialog .ui-resizable-se{width:14px;height:14px;right:3px;bottom:3px}.ui-draggable .ui-dialog-titlebar{cursor:move}.ui-progressbar{height:2em;text-align:left}.ui-progressbar .ui-progressbar-value{margin:-1px;height:100%}.ui-resizable{position:relative}.ui-resizable-handle{position:absolute;font-size:.1px;z-index:99999;display:block}.ui-resizable-disabled .ui-resizable-handle,.ui-resizable-autohide .ui-resizable-handle{display:none}.ui-resizable-n{cursor:n-resize;height:7px;width:100%;top:-5px;left:0}.ui-resizable-s{cursor:s-resize;height:7px;width:100%;bottom:-5px;left:0}.ui-resizable-e{cursor:e-resize;width:7px;right:-5px;top:0;height:100%}.ui-resizable-w{cursor:w-resize;width:7px;left:-5px;top:0;height:100%}.ui-resizable-se{cursor:se-resize;width:12px;height:12px;right:1px;bottom:1px}.ui-resizable-sw{cursor:sw-resize;width:9px;height:9px;left:-5px;bottom:-5px}.ui-resizable-nw{cursor:nw-resize;width:9px;height:9px;left:-5px;top:-5px}.ui-resizable-ne{cursor:ne-resize;width:9px;height:9px;right:-5px;top:-5px}.ui-selectable-helper{border:1px dotted black}.ui-slider{position:relative;text-align:left}.ui-slider .ui-slider-handle{position:absolute;z-index:2;width:1.2em;height:1.2em;cursor:default}.ui-slider .ui-slider-range{position:absolute;z-index:1;font-size:.7em;display:block;border:0;background-position:0 0}.ui-slider-horizontal{height:.8em}.ui-slider-horizontal .ui-slider-handle{top:-.3em;margin-left:-.6em}.ui-slider-horizontal .ui-slider-range{top:0;height:100%}.ui-slider-horizontal .ui-slider-range-min{left:0}.ui-slider-horizontal .ui-slider-range-max{right:0}.ui-slider-vertical{width:.8em;height:100px}.ui-slider-vertical .ui-slider-handle{left:-.3em;margin-left:0;margin-bottom:-.6em}.ui-slider-vertical .ui-slider-range{left:0;width:100%}.ui-slider-vertical .ui-slider-range-min{bottom:0}.ui-slider-vertical .ui-slider-range-max{top:0}.ui-tabs{position:relative;padding:.2em;zoom:1}.ui-tabs .ui-tabs-nav{margin:0;padding:.2em .2em 0}.ui-tabs .ui-tabs-nav li{list-style:none;float:left;position:relative;top:1px;margin:0 .2em 1px 0;border-bottom:0!important;padding:0;white-space:nowrap}.ui-tabs .ui-tabs-nav li a{float:left;padding:.5em 1em;text-decoration:none}.ui-tabs .ui-tabs-nav li.ui-tabs-selected{margin-bottom:0;padding-bottom:1px}.ui-tabs .ui-tabs-nav li.ui-tabs-selected a,.ui-tabs .ui-tabs-nav li.ui-state-disabled a,.ui-tabs .ui-tabs-nav li.ui-state-processing a{cursor:text}.ui-tabs .ui-tabs-nav li a,.ui-tabs.ui-tabs-collapsible .ui-tabs-nav li.ui-tabs-selected a{cursor:pointer}.ui-tabs .ui-tabs-panel{display:block;border-width:0;padding:1em 1.4em;background:0}.ui-tabs .ui-tabs-hide{display:none!important}.ui-widget{font-family:Verdana,Arial,sans-serif;font-size:1.1em}.ui-widget .ui-widget{font-size:1em}.ui-widget input,.ui-widget select,.ui-widget textarea,.ui-widget button{font-family:Verdana,Arial,sans-serif;font-size:1em}.ui-widget-content{border:1px solid #aaa;background:#fff url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-bg_flat_75_ffffff_40x100.png) 50% 50% repeat-x;color:#222}.ui-widget-content a{color:#222}.ui-widget-header{border:1px solid #aaa;background:#ccc url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-bg_highlight-soft_75_cccccc_1x100.png) 50% 50% repeat-x;color:#222;font-weight:bold}.ui-widget-header a{color:#222}.ui-state-default,.ui-widget-content .ui-state-default,.ui-widget-header .ui-state-default{border:1px solid #d3d3d3;background:#e6e6e6 url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-bg_glass_75_e6e6e6_1x400.png) 50% 50% repeat-x;font-weight:normal;color:#555}.ui-state-default a,.ui-state-default a:link,.ui-state-default a:visited{color:#555;text-decoration:none}.ui-state-hover,.ui-widget-content .ui-state-hover,.ui-widget-header .ui-state-hover,.ui-state-focus,.ui-widget-content .ui-state-focus,.ui-widget-header .ui-state-focus{border:1px solid #999;background:#dadada url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-bg_glass_75_dadada_1x400.png) 50% 50% repeat-x;font-weight:normal;color:#212121}.ui-state-hover a,.ui-state-hover a:hover{color:#212121;text-decoration:none}.ui-state-active,.ui-widget-content .ui-state-active,.ui-widget-header .ui-state-active{border:1px solid #aaa;background:#fff url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-bg_glass_65_ffffff_1x400.png) 50% 50% repeat-x;font-weight:normal;color:#212121}.ui-state-active a,.ui-state-active a:link,.ui-state-active a:visited{color:#212121;text-decoration:none}.ui-widget :active{outline:0}.ui-state-highlight,.ui-widget-content .ui-state-highlight,.ui-widget-header .ui-state-highlight{border:1px solid #fcefa1;background:#fbf9ee url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-bg_glass_55_fbf9ee_1x400.png) 50% 50% repeat-x;color:#363636}.ui-state-highlight a,.ui-widget-content .ui-state-highlight a,.ui-widget-header .ui-state-highlight a{color:#363636}.ui-state-error,.ui-widget-content .ui-state-error,.ui-widget-header .ui-state-error{border:1px solid #cd0a0a;background:#fef1ec url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-bg_glass_95_fef1ec_1x400.png) 50% 50% repeat-x;color:#cd0a0a}.ui-state-error a,.ui-widget-content .ui-state-error a,.ui-widget-header .ui-state-error a{color:#cd0a0a}.ui-state-error-text,.ui-widget-content .ui-state-error-text,.ui-widget-header .ui-state-error-text{color:#cd0a0a}.ui-priority-primary,.ui-widget-content .ui-priority-primary,.ui-widget-header .ui-priority-primary{font-weight:bold}.ui-priority-secondary,.ui-widget-content .ui-priority-secondary,.ui-widget-header .ui-priority-secondary{opacity:.7;filter:Alpha(Opacity=70);font-weight:normal}.ui-state-disabled,.ui-widget-content .ui-state-disabled,.ui-widget-header .ui-state-disabled{opacity:.35;filter:Alpha(Opacity=35);background-image:none}.ui-icon{width:16px;height:16px;background-image:url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-icons_222222_256x240.png)}.ui-widget-content .ui-icon{background-image:url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-icons_222222_256x240.png)}.ui-widget-header .ui-icon{background-image:url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-icons_222222_256x240.png)}.ui-state-default .ui-icon{background-image:url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-icons_888888_256x240.png)}.ui-state-hover .ui-icon,.ui-state-focus .ui-icon{background-image:url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-icons_454545_256x240.png)}.ui-state-active .ui-icon{background-image:url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-icons_454545_256x240.png)}.ui-state-highlight .ui-icon{background-image:url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-icons_2e83ff_256x240.png)}.ui-state-error .ui-icon,.ui-state-error-text .ui-icon{background-image:url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-icons_cd0a0a_256x240.png)}.ui-icon-carat-1-n{background-position:0 0}.ui-icon-carat-1-ne{background-position:-16px 0}.ui-icon-carat-1-e{background-position:-32px 0}.ui-icon-carat-1-se{background-position:-48px 0}.ui-icon-carat-1-s{background-position:-64px 0}.ui-icon-carat-1-sw{background-position:-80px 0}.ui-icon-carat-1-w{background-position:-96px 0}.ui-icon-carat-1-nw{background-position:-112px 0}.ui-icon-carat-2-n-s{background-position:-128px 0}.ui-icon-carat-2-e-w{background-position:-144px 0}.ui-icon-triangle-1-n{background-position:0 -16px}.ui-icon-triangle-1-ne{background-position:-16px -16px}.ui-icon-triangle-1-e{background-position:-32px -16px}.ui-icon-triangle-1-se{background-position:-48px -16px}.ui-icon-triangle-1-s{background-position:-64px -16px}.ui-icon-triangle-1-sw{background-position:-80px -16px}.ui-icon-triangle-1-w{background-position:-96px -16px}.ui-icon-triangle-1-nw{background-position:-112px -16px}.ui-icon-triangle-2-n-s{background-position:-128px -16px}.ui-icon-triangle-2-e-w{background-position:-144px -16px}.ui-icon-arrow-1-n{background-position:0 -32px}.ui-icon-arrow-1-ne{background-position:-16px -32px}.ui-icon-arrow-1-e{background-position:-32px -32px}.ui-icon-arrow-1-se{background-position:-48px -32px}.ui-icon-arrow-1-s{background-position:-64px -32px}.ui-icon-arrow-1-sw{background-position:-80px -32px}.ui-icon-arrow-1-w{background-position:-96px -32px}.ui-icon-arrow-1-nw{background-position:-112px -32px}.ui-icon-arrow-2-n-s{background-position:-128px -32px}.ui-icon-arrow-2-ne-sw{background-position:-144px -32px}.ui-icon-arrow-2-e-w{background-position:-160px -32px}.ui-icon-arrow-2-se-nw{background-position:-176px -32px}.ui-icon-arrowstop-1-n{background-position:-192px -32px}.ui-icon-arrowstop-1-e{background-position:-208px -32px}.ui-icon-arrowstop-1-s{background-position:-224px -32px}.ui-icon-arrowstop-1-w{background-position:-240px -32px}.ui-icon-arrowthick-1-n{background-position:0 -48px}.ui-icon-arrowthick-1-ne{background-position:-16px -48px}.ui-icon-arrowthick-1-e{background-position:-32px -48px}.ui-icon-arrowthick-1-se{background-position:-48px -48px}.ui-icon-arrowthick-1-s{background-position:-64px -48px}.ui-icon-arrowthick-1-sw{background-position:-80px -48px}.ui-icon-arrowthick-1-w{background-position:-96px -48px}.ui-icon-arrowthick-1-nw{background-position:-112px -48px}.ui-icon-arrowthick-2-n-s{background-position:-128px -48px}.ui-icon-arrowthick-2-ne-sw{background-position:-144px -48px}.ui-icon-arrowthick-2-e-w{background-position:-160px -48px}.ui-icon-arrowthick-2-se-nw{background-position:-176px -48px}.ui-icon-arrowthickstop-1-n{background-position:-192px -48px}.ui-icon-arrowthickstop-1-e{background-position:-208px -48px}.ui-icon-arrowthickstop-1-s{background-position:-224px -48px}.ui-icon-arrowthickstop-1-w{background-position:-240px -48px}.ui-icon-arrowreturnthick-1-w{background-position:0 -64px}.ui-icon-arrowreturnthick-1-n{background-position:-16px -64px}.ui-icon-arrowreturnthick-1-e{background-position:-32px -64px}.ui-icon-arrowreturnthick-1-s{background-position:-48px -64px}.ui-icon-arrowreturn-1-w{background-position:-64px -64px}.ui-icon-arrowreturn-1-n{background-position:-80px -64px}.ui-icon-arrowreturn-1-e{background-position:-96px -64px}.ui-icon-arrowreturn-1-s{background-position:-112px -64px}.ui-icon-arrowrefresh-1-w{background-position:-128px -64px}.ui-icon-arrowrefresh-1-n{background-position:-144px -64px}.ui-icon-arrowrefresh-1-e{background-position:-160px -64px}.ui-icon-arrowrefresh-1-s{background-position:-176px -64px}.ui-icon-arrow-4{background-position:0 -80px}.ui-icon-arrow-4-diag{background-position:-16px -80px}.ui-icon-extlink{background-position:-32px -80px}.ui-icon-newwin{background-position:-48px -80px}.ui-icon-refresh{background-position:-64px -80px}.ui-icon-shuffle{background-position:-80px -80px}.ui-icon-transfer-e-w{background-position:-96px -80px}.ui-icon-transferthick-e-w{background-position:-112px -80px}.ui-icon-folder-collapsed{background-position:0 -96px}.ui-icon-folder-open{background-position:-16px -96px}.ui-icon-document{background-position:-32px -96px}.ui-icon-document-b{background-position:-48px -96px}.ui-icon-note{background-position:-64px -96px}.ui-icon-mail-closed{background-position:-80px -96px}.ui-icon-mail-open{background-position:-96px -96px}.ui-icon-suitcase{background-position:-112px -96px}.ui-icon-comment{background-position:-128px -96px}.ui-icon-person{background-position:-144px -96px}.ui-icon-print{background-position:-160px -96px}.ui-icon-trash{background-position:-176px -96px}.ui-icon-locked{background-position:-192px -96px}.ui-icon-unlocked{background-position:-208px -96px}.ui-icon-bookmark{background-position:-224px -96px}.ui-icon-tag{background-position:-240px -96px}.ui-icon-home{background-position:0 -112px}.ui-icon-flag{background-position:-16px -112px}.ui-icon-calendar{background-position:-32px -112px}.ui-icon-cart{background-position:-48px -112px}.ui-icon-pencil{background-position:-64px -112px}.ui-icon-clock{background-position:-80px -112px}.ui-icon-disk{background-position:-96px -112px}.ui-icon-calculator{background-position:-112px -112px}.ui-icon-zoomin{background-position:-128px -112px}.ui-icon-zoomout{background-position:-144px -112px}.ui-icon-search{background-position:-160px -112px}.ui-icon-wrench{background-position:-176px -112px}.ui-icon-gear{background-position:-192px -112px}.ui-icon-heart{background-position:-208px -112px}.ui-icon-star{background-position:-224px -112px}.ui-icon-link{background-position:-240px -112px}.ui-icon-cancel{background-position:0 -128px}.ui-icon-plus{background-position:-16px -128px}.ui-icon-plusthick{background-position:-32px -128px}.ui-icon-minus{background-position:-48px -128px}.ui-icon-minusthick{background-position:-64px -128px}.ui-icon-close{background-position:-80px -128px}.ui-icon-closethick{background-position:-96px -128px}.ui-icon-key{background-position:-112px -128px}.ui-icon-lightbulb{background-position:-128px -128px}.ui-icon-scissors{background-position:-144px -128px}.ui-icon-clipboard{background-position:-160px -128px}.ui-icon-copy{background-position:-176px -128px}.ui-icon-contact{background-position:-192px -128px}.ui-icon-image{background-position:-208px -128px}.ui-icon-video{background-position:-224px -128px}.ui-icon-script{background-position:-240px -128px}.ui-icon-alert{background-position:0 -144px}.ui-icon-info{background-position:-16px -144px}.ui-icon-notice{background-position:-32px -144px}.ui-icon-help{background-position:-48px -144px}.ui-icon-check{background-position:-64px -144px}.ui-icon-bullet{background-position:-80px -144px}.ui-icon-radio-off{background-position:-96px -144px}.ui-icon-radio-on{background-position:-112px -144px}.ui-icon-pin-w{background-position:-128px -144px}.ui-icon-pin-s{background-position:-144px -144px}.ui-icon-play{background-position:0 -160px}.ui-icon-pause{background-position:-16px -160px}.ui-icon-seek-next{background-position:-32px -160px}.ui-icon-seek-prev{background-position:-48px -160px}.ui-icon-seek-end{background-position:-64px -160px}.ui-icon-seek-start{background-position:-80px -160px}.ui-icon-seek-first{background-position:-80px -160px}.ui-icon-stop{background-position:-96px -160px}.ui-icon-eject{background-position:-112px -160px}.ui-icon-volume-off{background-position:-128px -160px}.ui-icon-volume-on{background-position:-144px -160px}.ui-icon-power{background-position:0 -176px}.ui-icon-signal-diag{background-position:-16px -176px}.ui-icon-signal{background-position:-32px -176px}.ui-icon-battery-0{background-position:-48px -176px}.ui-icon-battery-1{background-position:-64px -176px}.ui-icon-battery-2{background-position:-80px -176px}.ui-icon-battery-3{background-position:-96px -176px}.ui-icon-circle-plus{background-position:0 -192px}.ui-icon-circle-minus{background-position:-16px -192px}.ui-icon-circle-close{background-position:-32px -192px}.ui-icon-circle-triangle-e{background-position:-48px -192px}.ui-icon-circle-triangle-s{background-position:-64px -192px}.ui-icon-circle-triangle-w{background-position:-80px -192px}.ui-icon-circle-triangle-n{background-position:-96px -192px}.ui-icon-circle-arrow-e{background-position:-112px -192px}.ui-icon-circle-arrow-s{background-position:-128px -192px}.ui-icon-circle-arrow-w{background-position:-144px -192px}.ui-icon-circle-arrow-n{background-position:-160px -192px}.ui-icon-circle-zoomin{background-position:-176px -192px}.ui-icon-circle-zoomout{background-position:-192px -192px}.ui-icon-circle-check{background-position:-208px -192px}.ui-icon-circlesmall-plus{background-position:0 -208px}.ui-icon-circlesmall-minus{background-position:-16px -208px}.ui-icon-circlesmall-close{background-position:-32px -208px}.ui-icon-squaresmall-plus{background-position:-48px -208px}.ui-icon-squaresmall-minus{background-position:-64px -208px}.ui-icon-squaresmall-close{background-position:-80px -208px}.ui-icon-grip-dotted-vertical{background-position:0 -224px}.ui-icon-grip-dotted-horizontal{background-position:-16px -224px}.ui-icon-grip-solid-vertical{background-position:-32px -224px}.ui-icon-grip-solid-horizontal{background-position:-48px -224px}.ui-icon-gripsmall-diagonal-se{background-position:-64px -224px}.ui-icon-grip-diagonal-se{background-position:-80px -224px}.ui-corner-tl{-moz-border-radius-topleft:4px;-webkit-border-top-left-radius:4px;border-top-left-radius:4px}.ui-corner-tr{-moz-border-radius-topright:4px;-webkit-border-top-right-radius:4px;border-top-right-radius:4px}.ui-corner-bl{-moz-border-radius-bottomleft:4px;-webkit-border-bottom-left-radius:4px;border-bottom-left-radius:4px}.ui-corner-br{-moz-border-radius-bottomright:4px;-webkit-border-bottom-right-radius:4px;border-bottom-right-radius:4px}.ui-corner-top{-moz-border-radius-topleft:4px;-webkit-border-top-left-radius:4px;border-top-left-radius:4px;-moz-border-radius-topright:4px;-webkit-border-top-right-radius:4px;border-top-right-radius:4px}.ui-corner-bottom{-moz-border-radius-bottomleft:4px;-webkit-border-bottom-left-radius:4px;border-bottom-left-radius:4px;-moz-border-radius-bottomright:4px;-webkit-border-bottom-right-radius:4px;border-bottom-right-radius:4px}.ui-corner-right{-moz-border-radius-topright:4px;-webkit-border-top-right-radius:4px;border-top-right-radius:4px;-moz-border-radius-bottomright:4px;-webkit-border-bottom-right-radius:4px;border-bottom-right-radius:4px}.ui-corner-left{-moz-border-radius-topleft:4px;-webkit-border-top-left-radius:4px;border-top-left-radius:4px;-moz-border-radius-bottomleft:4px;-webkit-border-bottom-left-radius:4px;border-bottom-left-radius:4px}.ui-corner-all{-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px}.ui-widget-overlay{background:#aaa url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-bg_flat_0_aaaaaa_40x100.png) 50% 50% repeat-x;opacity:.3;filter:Alpha(Opacity=30)}.ui-widget-shadow{margin:-8px 0 0 -8px;padding:8px;background:#aaa url(http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-bg_flat_0_aaaaaa_40x100.png) 50% 50% repeat-x;opacity:.3;filter:Alpha(Opacity=30);-moz-border-radius:8px;-webkit-border-radius:8px;border-radius:8px}");

									init_general_css();
									api_add_css_style('acp_colorbox_css', "#colorbox,#cboxOverlay,#cboxWrapper{position:absolute;top:0;left:0;z-index:9999;overflow:hidden}#cboxOverlay{position:fixed;width:100%;height:100%}#cboxMiddleLeft,#cboxBottomLeft{clear:left}#cboxContent{position:relative}#cboxLoadedContent{overflow:auto}#cboxTitle{margin:0}#cboxLoadingOverlay,#cboxLoadingGraphic{position:absolute;top:0;left:0;width:100%;height:100%}#cboxPrevious,#cboxNext,#cboxClose,#cboxSlideshow{cursor:pointer}.cboxPhoto{float:left;margin:auto;border:0;display:block}.cboxIframe{width:100%;height:100%;display:block;border:0}#colorbox,#cboxContent,#cboxLoadedContent{box-sizing:content-box}#cboxOverlay{background:#fff}#cboxTopLeft{width:25px;height:25px;background:url(http://clients.autocompleteplus.com/images/border1.png) no-repeat 0 0}#cboxTopCenter{height:25px;background:url(http://clients.autocompleteplus.com/images/border1.png) repeat-x 0 -50px}#cboxTopRight{width:25px;height:25px;background:url(http://clients.autocompleteplus.com/images/border1.png) no-repeat -25px 0}#cboxBottomLeft{width:25px;height:25px;background:url(http://clients.autocompleteplus.com/images/border1.png) no-repeat 0 -25px}#cboxBottomCenter{height:25px;background:url(http://clients.autocompleteplus.com/images/border1.png) repeat-x 0 -75px}#cboxBottomRight{width:25px;height:25px;background:url(http://clients.autocompleteplus.com/images/border1.png) no-repeat -25px -25px}#cboxMiddleLeft{width:25px;background:url(http://clients.autocompleteplus.com/images/border2.png) repeat-y 0 0}#cboxMiddleRight{width:25px;background:url(http://clients.autocompleteplus.com/images/border2.png) repeat-y -25px 0}#cboxContent{background:#fff;overflow:hidden}.cboxIframe{background:#fff}#cboxError{padding:50px;border:1px solid #ccc}#cboxLoadedContent{margin-bottom:20px}#cboxTitle{position:absolute;bottom:0;left:0;text-align:center;width:100%;color:#999}#cboxCurrent{position:absolute;bottom:0;left:100px;color:#999}#cboxSlideshow{position:absolute;bottom:0;right:42px;color:#444}#cboxPrevious{position:absolute;bottom:0;left:0;color:#444}#cboxNext{position:absolute;bottom:0;left:63px;color:#444}#cboxLoadingOverlay{background:#fff url(http://clients.autocompleteplus.com/images/loading.gif) no-repeat 5px 5px}#cboxClose{position:absolute;bottom:0;right:0;display:block;color:#444}.cboxIE #cboxTopLeft,.cboxIE #cboxTopCenter,.cboxIE #cboxTopRight,.cboxIE #cboxBottomLeft,.cboxIE #cboxBottomCenter,.cboxIE #cboxBottomRight,.cboxIE #cboxMiddleLeft,.cboxIE #cboxMiddleRight{filter:progid:DXImageTransform.Microsoft.gradient(startColorstr=#00FFFFFF,endColorstr=#00FFFFFF)}.cboxIE6 #cboxTopLeft{background:url(http://clients.autocompleteplus.com/images/ie6/borderTopLeft.png)}.cboxIE6 #cboxTopCenter{background:url(http://clients.autocompleteplus.com/images/ie6/borderTopCenter.png)}.cboxIE6 #cboxTopRight{background:url(http://clients.autocompleteplus.com/images/ie6/borderTopRight.png)}.cboxIE6 #cboxBottomLeft{background:url(http://clients.autocompleteplus.com/images/ie6/borderBottomLeft.png)}.cboxIE6 #cboxBottomCenter{background:url(http://clients.autocompleteplus.com/images/ie6/borderBottomCenter.png)}.cboxIE6 #cboxBottomRight{background:url(http://clients.autocompleteplus.com/images/ie6/borderBottomRight.png)}.cboxIE6 #cboxMiddleLeft{background:url(http://clients.autocompleteplus.com/images/ie6/borderMiddleLeft.png)}.cboxIE6 #cboxMiddleRight{background:url(http://clients.autocompleteplus.com/images/ie6/borderMiddleRight.png)}.cboxIE6 #cboxTopLeft,.cboxIE6 #cboxTopCenter,.cboxIE6 #cboxTopRight,.cboxIE6 #cboxBottomLeft,.cboxIE6 #cboxBottomCenter,.cboxIE6 #cboxBottomRight,.cboxIE6 #cboxMiddleLeft,.cboxIE6 #cboxMiddleRight{_behavior:expression(this.src = this.src ? this.src:this.currentStyle.backgroundImage.split('\"')[1],this.style.background = \"none\",this.style.filter = \"progid:DXImageTransform.Microsoft.AlphaImageLoader(src=\"+this.src+\", sizingMethod='scale')\")}");
									if (this_host.indexOf('22find')>=0)	{
										api_add_css_style('acp2', 'body .ui-autocomplete {width: auto !important;}');
									}
									api_update_stats( __acp.STATS_SITE_SUPPORTED );									
									if (__acp.input_id_0 == '')	{
										__acp.input_id_0 = __acp.missing_input_id_0;
										the_client_input_0.setAttribute('id', __acp.input_id_0);
									}
									if (the_client_input_1 != null && __acp.input_id_1 == '')	{
										__acp.input_id_1 = __acp.missing_input_id_1;
										the_client_input_1.setAttribute('id', __acp.input_id_1);
									}

		     						__acp.input_id_0 = '#' + __acp.input_id_0;
		     						var element_0 = $jquery(__acp.input_id_0);	

									if (__acpParams.open_suggestions_on_focus)	{			
										$jquery(__acp.input_id_0).focus(function()	{
											$jquery(__acp.input_id_0).autocomplete("search", $jquery(__acp.input_id_0).val());											
										});
										if (the_client_input_1 != null && __acp.input_id_1 == '')	{
											$jquery(__acp.input_id_1).focus(function()	{
												$jquery(__acp.input_id_1).autocomplete("search", $jquery(__acp.input_id_1).val());												
											});										
										}
										
									}										
									
									
									try	{										
										if ( __acpParams.focus_on_searchbox 
											 && element_0.offset().top>$jquery(window).scrollTop() && element_0.offset().top < ($jquery(window).scrollTop() + $jquery(window).height() )
											 && document.activeElement.nodeName.toLowerCase()!= 'input' )	{
											 
											element_0.focus();
											element_0.val('');
											setTimeout( function() { $jquery('#' + __acp.css_init_element_id).removeClass("ui-autocomplete-loading"); }, 1111);											
										}
									}	catch (e)	{}
									
									if (the_client_input_1 != null)	{
		     							__acp.input_id_1 = '#' + __acp.input_id_1;
		     							var element_1 = $jquery( __acp.input_id_1 );
		     						}
		     								     						
		     						var inputs_list = __acp.input_id_0; if (the_client_input_1 != null)	{	inputs_list += ',' +__acp.input_id_1;	} 
									function mix_history_suggestions(term, data_sug)	{									
										var local_history = getSiteUserHistory(term, __acp.max_autocomplete_personal);															
										var data_items = new Array();												
										var temp_list;
										if (local_history.length==0)	{
											data_items = data_sug;											
										}	else	{  	// TODO: support personal items in the middle between popular and related (low priority todo...)
											if (__acp.autocomplete_order[0]=='personal')	{	
												data_items = local_history;
												temp_list  = data_sug;
											}	else	{
												data_items = data_sug;
												temp_list  = local_history;												     				    		
											}	
											// validate no double showing for the same term... might be in the previous history as well as in the populars												     				    												     				    	
											for (var j=0;j<temp_list.length;j++)	{	// Don't enfore max_autocomplete_total anymore: && data_items.length<__acp.max_autocomplete_total
												var newO = temp_list[j];
												var add_item = true;
												for (var i=0;i<data_items.length;i++)	{
													if (data_items[i].label == newO.label)	{	add_item=false;	break;	}												     				    		
												}
												if (add_item)	{	data_items.push(newO);	}
											}											     				    	
										}				
										if (__acp.ACP_AMAZON_LATEST_SUGGEST != null)	{
											var newObj = new Object();
											newObj.label = __acp.ACP_AMAZON_LATEST_SUGGEST;
											if (__acp.ACP_AMAZON_ENABLE ==1)	{
												newObj.type  = __acp.AMAZON_SUGGESTION;
											}	else	{
												newObj.type  = __acp.RELATED_SUGGESTION;											
											}
											data_items.push(newObj);
										}									
										
										
										return get_non_repeating_related_suggestions(data_items);
									}
									
									function get_amazon_suggest(term)	{										
										__acp.ACP_AMAZON_LATEST_SUGGEST = null;									
										if (term.length < __acp.ACP_AMAZON_SHOW_MIN_CHAR) {	return;	}
										var cur_term_words = term.split(' ');
										if (cur_term_words.length < __acp.ACP_AMAZON_SHOW_MIN_WORD) {	return;	}
										api_get_amazon_suggest(__acp.ACP_AMAZON_COMPLETE_URL.replace('{searchTerms}', term), 
															   function(data){
																	__acp.ACP_AMAZON_LATEST_SUGGEST = data;
															   });									
									}
									function get_non_repeating_related_suggestions(data_items)	{
										var ret_data_items = new Array();
										for (var j=0;j<data_items.length;j++)	{											
											var found_already = false;
											for (var i=0;i<j;i++)	{
												if (data_items[i].type == data_items[j].type && data_items[i].label ==data_items[j].label)	{													
													found_already = true;
													break;
												}											
											}
											if (!found_already)	{
												ret_data_items.push(data_items[j]);
											}
										}
										return ret_data_items;
									}
												
									
									function render_acp_personal(term, ac_response)	{										
										var tar_url = __acp.SERVER_URL + "/?q=" + encodeURIComponent(term.toLowerCase()) + "&p=" + __acpParams.PARTNER_ID + "&l=" + encodeURIComponent(this_host) + "&v=" + __acp.CLIENT_VER;
										api_ajax_request_get ( __acp.AJAX_QUERY,
											tar_url,																		
											function( data_sug ) {													
												var server_term   = data_sug.term;	
												if (__acp.ab_test == null)	{	
													// First request...
													__acp.ab_test = data_sug.ab;	
												}	else	{
													// Subsequent requests...
													if (__acp.ab_test != data_sug.ab)	{
														// Not consistent with prior requests...
														__acp.ab_test = ''; 
													}													
												}
												if (__acp.ab_test_source == null && data_sug.items.length>=4)	{
													__acp.ab_test_source = __acp.AB_TEST_SOURCE_PERSONAL;
												}	
												
												
												var inputbox_term = $jquery.trim($jquery('#' + __acp.css_init_element_id).val().toLowerCase());
												
												if ( server_term  != inputbox_term )	{
													ac_response( $jquery(__acp.requests_cache[ inputbox_term ]) );
													return;	
												}

												
												var data_items_followups = getFollowups(term, __acp.max_followups);
												if (data_items_followups.length>0)	{
													var the_items = new Array();
													the_items = data_items_followups.concat(data_items_followups, data_sug.items);														
													
												}	else	{
													the_items = data_sug.items;
												}
												
												__acp.latest_acp_personal_term 		= term;												
												__acp.latest_acp_personal_res_len 	= the_items.length;												
												
												if ( the_items.length < __acp.max_autocomplete_total)	{
													render_acp_global(term, ac_response, the_items);	
												}	else	{
													var data_items = new Array();
													data_items = mix_history_suggestions(term, the_items);					

													__acp.requests_cache[data_sug.term] = (data_items);													
													if (data_items.length >0)	{ 													
														__acp.latest_data_obj = data_items;																																											
													}																										
													ac_response( $jquery( data_items) );												
												}
											}
										);													
									}
									
									function render_acp_global(term, ac_response, acp_personal_items)	{
										var navLang = (navigator.language) ? navigator.language : navigator.userLanguage;
										var tar_url = __acp.AC_GLOBAL_URL + '/?q=' + encodeURIComponent(term.toLowerCase()) + '&l=' + navLang.substring(0,2) + '&c=' + __acp.ACP_COUNTRY_CODE;
										
										__acp.ab_test_source = __acp.AB_TEST_SOURCE_GLOBAL;
										
										api_ajax_request_get ( __acp.AJAX_QUERY_GL,
											tar_url,																		
											function( data_sug ) {																														
												// GLOBAL search site...
												var server_term   = data_sug.query;
												var inputbox_term = $jquery('#' + __acp.css_init_element_id).val().toLowerCase();
												
												if ( server_term  != inputbox_term )	{
													ac_response( $jquery(__acp.requests_cache[ inputbox_term ]) );
													return;	
												}														
												
												var data_items = new Array();	

												
												if (acp_personal_items != null)	{	data_items = acp_personal_items;	}
												var initial_suggestion_len = data_items.length;
												var suggestions_to_add = __acp.max_autocomplete_total;
												
												if (__acpParams.what_you_type_suggestion && __acpParams.what_you_type_position_first && __acp.site_status != __acp.ACP_SITE_GLOBAL_RELATED)	{
													var newObj = new Object();	newObj.label = term;	newObj.type  = __acp.RELATED_SUGGESTION;	data_items.push(newObj);													
												}
												
												for (var j=0; j<data_sug.items.length && j<suggestions_to_add && data_items.length<__acp.max_autocomplete_total; j++)	{
													var newObj   = new Object();
													if (is_profanity(data_sug.items[j]))	{	continue;	}
													newObj.label = data_sug.items[j];
													if (  
														 (__acp.site_status == __acp.ACP_SITE_SUPPORTED || (__acp.site_status == __acp.ACP_SITE_GLOBAL_SEARCH && __acp.profile_type > 0))
														 && ((initial_suggestion_len+j)/__acp.max_autocomplete_total)<= __acpParams.global_search_portals_popular_ratio 
														)	{
														newObj.type == __acp.POP_SUGGESTION;
													}	else	{
														newObj.type  = __acp.RELATED_SUGGESTION;
													}
													data_items.push( newObj );
												}	
												
												if (__acpParams.what_you_type_suggestion 
													&& (__acp.site_status == __acp.ACP_SITE_GLOBAL_RELATED || __acpParams.what_you_type_position_first==false) 
													&& data_items.length<__acp.max_autocomplete_total)	{
													var newObj = new Object();	newObj.label = term;	newObj.type  = __acp.RELATED_SUGGESTION;	data_items.push(newObj);
												}
												
												var data_sug = new Object();
												data_sug.items = data_items;
												data_items = mix_history_suggestions(term, data_sug.items);
												
												__acp.requests_cache[server_term] 	= (data_items);	
												if (data_items.length >0)	{ 
													__acp.latest_data_obj = data_items;															
												}																					
												ac_response( $jquery(data_items) );																
											}
										);												
									}
												
									var ac_position = { my: "left top", at: "left bottom", collision: "none" };
									if (this_host.indexOf('search.iminent.com') >= 0 )	{
										ac_position = { my: "left top", at: "left bottom", collision: "none", offset: "-5 7" };										
									}
									if (this_host.indexOf('start.iminent.com') >= 0)	{
										ac_position = { my: "left top", at: "left bottom", collision: "none", offset: "-31 3" };										
									}
									if (this_host.indexOf('msn.com') >= 0)	{
										ac_position = { my: "left top", at: "left bottom", collision: "none", offset: "-7 9" };										
									}
									ac_obj = $jquery(inputs_list).autocomplete({
										delay: 0,										
										position: ac_position,
							        	minLength: 0,							        	
							            source: function(request, ac_response) {	
											setTimeout( function() { $jquery('#' + __acp.css_init_element_id).removeClass("ui-autocomplete-loading"); }, 1111);
											
							            	if ( the_client_input_0.getAttribute('autocomplete') == 'off' || (__acpParams.PORN_FILTER && __acp.porn_site) )	{	
												// Something changed the autocomplete property from __acp.ac_OfF to 'off'
												// server_report('Collisioned script changed autocomplete property | autocomplete==' + the_client_input_0.getAttribute('autocomplete'));
												ac_response( null );
							            		return;
							            	}
											if ( api_db_get( __acp.ACP_DISABLED_KEY_GENERAL, true  ) == '1' || api_db_get( __acp.ACP_DISABLED_KEY + this_host, false ) == '1' )	{	return;	}

							                var term = request.term.replace(/&/g, '%26');		

											if 	(term.indexOf('<')>=0 || term.indexOf('>')>=0)	{
												ac_response( null );
												return;
											}
											get_amazon_suggest(term);					
											
											if (__acp.css_init_element_id != this.element.attr("id"))	{ 
												init_site_css (this.element); 
												var stam = String(this.element.attr("id"));
												__acp.css_init_element_id = stam;															
											}

							                if (term.length > 0 && term.length < 50) {										
												if (term in __acp.requests_cache) {
							                    	__acp.latest_data_obj = __acp.requests_cache[term];
							                        ac_response( $jquery(__acp.requests_cache[term]) );
							                        return;
							                    }		
												
												if (__acp.site_status == __acp.ACP_SITE_GLOBAL_SEARCH || __acp.site_status == __acp.ACP_SITE_GLOBAL_RELATED ||
													(__acp.latest_acp_personal_res_len==0 && term.length>=2 && term.length>=__acp.latest_acp_personal_term.length && term.indexOf(__acp.latest_acp_personal_term)==0))	{
													render_acp_global(term, ac_response, null);
												}	else	{
													render_acp_personal(term, ac_response);
												}
												
							                }	else	{
							                	// searchox is empty now (after deleting stuff)... let's close the dropdown
												if (__acpParams.open_suggestions_on_focus && __acp.site_status == __acp.ACP_SITE_SUPPORTED)	{
													var data_items		 = getFollowups('', __acp.max_followups);
													var data_items_his 	 = getSiteUserHistory('', Math.min(__acp.max_autocomplete_personal, __acp.max_autocomplete_total-data_items.length));
													data_items.push.apply(data_items, data_items_his);	
													/*
													Don't show top site terms upon focus...
													var data_items_top = getTopSiteSearches( __acp.max_autocomplete_total-data_items.length );
													// unsafeWindow.console.log(data_items_top);																																					
													data_items.push.apply(data_items, data_items_top);	
													*/

													if (data_items.length > 0)	{														
														__acp.requests_cache[''] 	= data_items;																																							
														__acp.latest_data_obj 		= data_items;
													}
														
													ac_response( $jquery( data_items) );
													return;
												}
												
												$jquery('#' + __acp.css_init_element_id).removeClass("ui-autocomplete-loading"); 
												this.close();
							                }
							            },	// end of source:							            
							            
							            search: function(event, ui) { 
							            	__acp.focused_item_type = null;							            	
							            	__acp.focused_item_label = null;								            	
							            },
							            focus: function(event, ui)	{
							            	__acp.focused_item_type  = ui.item.type;							            	
							            	__acp.focused_item_label = ui.item.label;		
							            },
							            select: function(event, ui) {
							            	// event.preventDefault();
							            	// event.stopImmediatePropagation();
						            		var input_element = $jquery('#' + __acp.css_init_element_id);
											var orig_term	  = input_element.val();
											
				     						input_element.val( ui.item.label );
				     						var the_term = input_element.val();		// ui.item.label
							            	var enter_key=!1;13==event.which&&(enter_key=!0);
											var ui_item_type = ui.item.type;
																						
											switch (ui.item.type)	{
												case __acp.AMAZON_SUGGESTION:
													navigate(get_amazon_redirect_url(the_term), __acp.search_target, enter_key);		
													return false;
												case __acp.RELATED_SUGGESTION:
													try	{
														api_update_stats( __acp.STATS_USE_RELATED );														
														server_loopback( the_term, true, false, orig_term );	// don't send to server but add to local history	
													}	catch (e)	{}
													navigate(get_search_redirect_url(the_term), __acp.search_target, enter_key);		// navigate within the current window
													return false;																
												default:																		            								            	
													if (ui_item_type == __acp.POP_SUGGESTION )	{	
														api_update_stats( __acp.STATS_USE_POP );																
													}
													if (ui_item_type == __acp.HISTORY_SUGGESTION )	{																
														api_update_stats( __acp.STATS_USE_HISTORY );														
													}
													server_loopback( the_term, true, true, orig_term );	// send to server + to local history							            	

													if (__acp.search_dest == 1)	{
														// use the partner's search destination with a domain site search 
														var tari = this_host.replace('www.','').replace('search.','');
														api_update_stats( __acp.STATS_USE_RELATED );
														navigate( get_search_redirect_url(the_term+' site:'+ tari), __acp.search_target, enter_key );
														return false;
													}	else	{										
														// use the original site's search results page					
														var thisLevel = input_element.parent();
		
														for (var level=0;level<10;level++)	{
															// DON'T DELETE THIS... decoy... levels are not really used here...
															try	{
																if (thisLevel.get(0).tagName.toLowerCase() == 'form')	{	thisLevel.submit();	continue;	}
															}	catch(f)	{}
															var inputs = thisLevel.find('input[type=submit],input[type=default],input[type=button],input[type=image],button[type=submit],button[type=default],button[type=button],button[type=image]');	
															if (inputs.length>0)	{	inputs[0].click();	return;		}								            		
															var inputs  = thisLevel.find('a');	
															for (var i=0;i<inputs.length;i++)	{
																var ht = getNodeHTML(inputs[i]);
																if (ht.indexOf('srch')>=0 || ht.indexOf('search')>=0)	{	inputs[i].click();	return;	}
															}
															if (inputs == null)		{	break;	}

															thisLevel = thisLevel.parent();								            		
														}

														input_element.focus();	
														//$jquery(event.target.form).submit();
														//input_element.closest("form").submit();	
													}	
													break;
											}	// end of switch											
	            							            		
							             },	// end of select:
							            										
							            open: function(event, ui) {		
											$jquery('#' + __acp.css_init_element_id).removeClass("ui-autocomplete-loading");											
											
							            	$jquery("ul.ui-autocomplete").each(function(index) {	
							            		if ( $jquery(this).css('display') != 'none')	{													
													// Width...
													var wid = $jquery('#' + __acp.css_init_element_id).outerWidth();	

													// try with the <form> width...
													var form_width = null;													
													var my_form = $jquery('#' + __acp.css_init_element_id).closest('form');
													if (my_form	!= null && my_form.length != 0 && my_form.outerWidth() != null && my_form.outerWidth() < __acpParams.MAX_SUGGEST_WIDTH && my_form.offset().left != null)	{	
														var form_offset = my_form.offset().left;	
														var input_offset= $jquery('#' + __acp.css_init_element_id).offset().left;																
														form_width = my_form.outerWidth() - (input_offset-form_offset);																	
													}	
													if (form_width != null)	{	wid = form_width;	}

													// Still very narrow width...
													var parent_element_width = null;
													
													if	( wid < __acpParams.MIN_SUGGEST_FORM_WIDTH )	{	
														// Go up the DOM to find the widest...
														var thisLevel = $jquery('#' + __acp.css_init_element_id).parent();
		
														for (var level=0;level<20 && thisLevel != null && thisLevel.length != 0;level++)	{	
															if (thisLevel.outerWidth() != null && thisLevel.outerWidth() < __acpParams.MAX_SUGGEST_WIDTH && thisLevel.offset().left != null && thisLevel.offset().left != 0)	{	
																var form_offset 	 = thisLevel.offset().left;	
																var input_offset	 = $jquery('#' + __acp.css_init_element_id).offset().left;																
																parent_element_width = thisLevel.outerWidth() - (input_offset-form_offset);
																
															}	
															thisLevel = thisLevel.parent();								            		
														}				
														if (parent_element_width != null)	{	wid = parent_element_width;	}														
													}
													if (wid < __acpParams.MIN_SUGGEST_WIDTH)	{	wid = __acpParams.MIN_SUGGEST_WIDTH;	}
													$jquery(this).outerWidth( wid );
													// Web Results splitter...
													if (__acpParams.suggest_diff_style == 'line')	{
														var first_related = $jquery('.as_rel');																												
														if (first_related.length > 0)	{
															first_related[0].parentNode.parentNode.className += " acp_sep_top";																																
															first_related[0].parentNode.innerHTML = ( '<div class="acp_sep">' + escapeHTML(__acpParams.suggest_diff_text_rel) + '</div>' + first_related[0].parentNode.innerHTML );
														}
													}
													if (__acpParams.suggest_diff_style == 'desc')	{
														var items = $jquery('.as_rel');
														if (items.length>0)	{
															items[0].innerHTML += ( '<span class="acp_desc acp_desc_rel"> - ' + escapeHTML(__acpParams.suggest_diff_text_rel) + '</span>' );
														}
														var items = $jquery('.as_pop');
														if (items.length>0)	{
															items[0].innerHTML += ( '<span class="acp_desc acp_desc_pop"> - ' + escapeHTML(__acpParams.suggest_diff_text_pop) + '</span>' );
														}
														var items = $jquery('.as_his');
														if (items.length>0)	{
															items[0].innerHTML += ( '<span class="acp_desc acp_desc_his"> - ' + escapeHTML(__acpParams.suggest_diff_text_his) + '</span>' );
														}																													
													}
													
													// Footer...													
													if (__LTR==false)	{
														__acpParams.footer_css = __acpParams.footer_css.replace('float:right', 'float:left');
													}
													$jquery(".ui-autocomplete").append("<li style='" + __acpParams.footer_css + "'><a style='text-decoration:none;font-weight:normal;font-size:10px;' href='#' id='acp_footer_cfg_007' title='" + __acpParams.footer_tooltip +"'>" + __acpParams.footer_html +"</a></li>");
													$jquery("#acp_footer_cfg_007").click(open_configuration);																										
							            		}
											});							            					          							                							                
							            }	// end of open:							            
							        });	 //	end of ac_obj autocomplete			
																		
									// Attach _renderItem for every autocompelte component...									
									$jquery(__acp.input_id_0).autocomplete().data( "autocomplete" )._renderItem = function( ul, item ) 		{	return dropdown_renderItem(ul, item);	}
									if (the_client_input_1 != null)	{	
										$jquery(__acp.input_id_1).autocomplete().data( "autocomplete" )._renderItem = function( ul, item ) 	{	return dropdown_renderItem(ul, item);	}
									} 									
									
									// Attach a handler to get the [ENTER] on free text stuff
									attach_loopback_handler( element_0, the_client_form_0 );	
		     						if (the_client_input_1 != null)	{	attach_loopback_handler( element_1, the_client_form_1 );	}							
									
									// Mark the autocomplete property in a unique way (JQuery UI set it to "off")
								    the_client_input_0.setAttribute('autocomplete', __acp.ac_OfF);	 the_client_input_0.autocomplete = __acp.ac_OfF; 
									
									
								    if (the_client_input_1 !=null)  {	the_client_input_1.setAttribute('autocomplete', __acp.ac_OfF);	the_client_input_1.autocomplete = __acp.ac_OfF; }
									//if (the_client_form_0 != null)	{	the_client_form_0.setAttribute('autocomplete', __acp.ac_OfF);	}
									//if (the_client_form_1 != null)	{	the_client_form_1.setAttribute('autocomplete', __acp.ac_OfF);	}		
									

									

																		
							        function init_site_css(search_element) {										
										var uni_css_id = "as_css_style_x_007";
										$jquery('#'+uni_css_id).remove();

										// some rules to apply
										var back_color = search_element.css('background-color');
										if (back_color == 'transparent')	{	back_color = '#fdfdfd';	}
										var padding_left = search_element.css('padding-left').replace('px','');
										if (padding_left>16)	padding_left = ';';
											else				padding_left = ";padding-left: " + search_element.css('padding-left');
	
										LTR_stuff = ';';
										if (__LTR==false)	{
											LTR_stuff = ';text-align:right;';
										}
										var icon_suffix = 16;
										var icon_padding_left = '22px';
										var icon_position_y = 4;
										var font_size_css = search_element.css('font-size');
										var font_size = parseInt(font_size_css.replace('px',''), 10);
										var font_style = search_element.css('font-style');																				
										if (font_size<15)					{ icon_suffix = 12;	icon_padding_left = '16px';	icon_position_y=3;}
										if (font_size>22)					{ icon_suffix = 26;	icon_padding_left = '32px';  icon_position_y=8;}										
										var element_height = search_element.css('height');																			
										var element_line_height = search_element.css('line-height');																			
										var font_weight = 'bold';	// search_element.css('font-weight');
										icon_position_y = "50%";	//	icon_position_y + "px";
										var rules = {
										   ".ui-draggable .ui-dialog-titlebar": "{border-radius:4px 4px 0 0;;font-size:	" + font_size_css + ";font-weight: normal;font-family:"	+search_element.css('font-family')+ "}",
										   
										   ".n_b_acp": "{ font-weight: normal; color: #555; font-size:" + font_size_css + "}",
									   
   										   ".ui-autocomplete" : "{ max-height:none;overflow-y:auto; position:absolute;background-image:none; cursor:default; z-index:9999999999 !important; }",
										   ".ui-autocomplete .ui-menu-item": "{content:''; list-style-type: none; background-image:none; text-align: left;}",
										   ".ui-autocomplete .ui-menu-item:before": "{content:''; }",							   										   
										   
										   ".as_icon":  "{color: #000; overflow-x:hidden;text-overflow: ellipsis;white-space:nowrap;background-repeat: no-repeat;padding-top:0;padding-bottom:0;" + 
														";background-position:1px "+icon_position_y + 
														";padding-left:"+icon_padding_left+" !important " + 
														/*";line-height:" + element_line_height +
														";height:" + element_height +*/
														";min-height:" + (font_size + 2) + "px" + 
														";font-size:" + font_size_css +"}",
										   ".as_pop": "{ background-image: url('"+__acp.SERVER_URL+"/images/search_"+icon_suffix+".png'); }",
										   ".as_rel": "{ background-image: url('"+__acp.SERVER_URL+"/images/related_"+icon_suffix+".png'); }",
										   ".as_his": "{ background-image: url('"+__acp.SERVER_URL+"/images/history_"+icon_suffix+".png'); }",
										   ".as_amzn": "{ background-image: url('"+__acp.SERVER_URL+"/images/amazon_"+icon_suffix+".png'); }",										   
										   
										   ".ui-autocomplete .ui-menu-item #ui-active-menuitem": "{background-color:#cacaca; margin:0; font-weight:"	+font_weight +"}",
										   ".ui-autocomplete .ui-menu-item .ui-corner-all": "{border-radius:0;margin:0;border-width:0; background-image:none;color: #000 !important; text-align: left;"+
																							 ";padding-top: "		+search_element.css('padding-top')+
										   													 ";padding-bottom: "	+search_element.css('padding-bottom')+
																							 padding_left +			// NOT a TYPO
																							 LTR_stuff + 
										   													 // ";padding-right: "		+search_element.css('padding-right')+
										   													 ";font-size: 	"		+font_size_css+
										   													 ";text-transform:"		+search_element.css('text-transform')+
 										   													 ";font-style:"			+font_style+								   													 																							 
																							 ";font-weight:"		+font_weight+								   													 
										   													 ";font-family:"		+search_element.css('font-family')+ "}"
										   													 
										}
										// loop through and insert
										var css_stuff = '';
										for (selector in rules) {	css_stuff += (selector + rules[selector]);	}
										
										api_add_css_style(uni_css_id, css_stuff);										
									}	// end of init_site_css	  
									
									break;
								default:	// Unknown yet...
									api_update_stats( __acp.STATS_SITE_NEW );									
									__acp.input_id_0 = '#' + __acp.input_id_0;
									var element_0 = $jquery(__acp.input_id_0);
									if (the_client_input_1 != null)	{
										__acp.input_id_1 = '#' + __acp.input_id_1;
										var element_1 = $jquery( __acp.input_id_1 );
									}
									
									attach_loopback_handler( element_0, the_client_form_0 );	
									if (the_client_input_1 != null)	{	attach_loopback_handler( element_1, the_client_form_1 );	}
									return;							     						
								}	//	END of main SWITCH		     					
								

     					} // end of success...
			)	; // end of appAPI.request
	

	initLocalHistory();	
		
	function dropdown_renderItem(ul, item)	{
			// <li class="ui-menu-item" role="menuitem">
			//		<a class="ui-corner-all" tabindex="-1">
			//			<div title="bill clinton s birth certificate - Search the web" class="as_rel as_icon">bill clinton s birth certificate</div>
			//		</a>
			// </li>
			var line_term = item.label;
			var line_term_tooltip = line_term.replace('&', '&amp;');
			var line_class, line_tooltip;
			switch (item.type)	{
				case __acp.RELATED_SUGGESTION:	line_class = 'as_rel'; line_tooltip = line_term_tooltip + __acpParams.related_suggest_tooltip; 		break;
				case __acp.HISTORY_SUGGESTION:	line_class = 'as_his'; line_tooltip = line_term_tooltip + __acpParams.history_suggest_tooltip;		break;
				case __acp.AMAZON_SUGGESTION:	line_class = 'as_amzn'; line_tooltip = line_term_tooltip + __acpParams.amazon_suggest_tooltip;		break;												
				default:						line_class = 'as_pop'; line_tooltip = line_term_tooltip + __acpParams.popular_suggest_tooltip;			
			}
			var curr_query = $jquery('#' + __acp.css_init_element_id).val().toLowerCase();							  
			var line_term_highlight = highlight_term(curr_query, line_term);
			
			var li_class = line_class + ' as_icon';
			if (__acp.site_status == __acp.ACP_SITE_GLOBAL_RELATED)	{	li_class = "";	}
					
			return $jquery( "<li></li>" )
				.data( "item.autocomplete", item )
				.append( "<a href='#'>" + "<div title=\""+line_tooltip+"\" class=\"" + li_class + "\">" + line_term_highlight + "</div>" + "</a>" )
				.appendTo( ul );													
	}

	function edit_distance(a, b)	{ 
		// the 2 strings to compare
		  var c,d,e,f,g;
		  for(d=[e=0];a[e];e++) // loop through a and reset the 1st distance
			for(c=[f=0];b[++f];) // loop through b and reset the 1st col of the next row
			  g=
			  d[f]=
				e? // not the first row ?
				1+Math.min( // then compute the cost of each change
				  d[--f],
				  c[f]-(a[e-1]==b[f]),
				  c[++f]=d[f] // and copy the previous row of the distance matrix
				)
				: // otherwise
				f; // init the very first row of the distance matrix
		  return g;
	}

	function get_word_distance(curr_query_word, line_term_word)	{
		var i = line_term_word.indexOf(curr_query_word);				
		return i;						
		var line_term_word_prefix = line_term_word.substring(0, curr_query_word.length);
		if (curr_query_word == line_term_word_prefix)	{	return 0;	}
		return 1;
		var dist = edit_distance(curr_query_word, line_term_word_prefix);
		if ( (dist == 3 && curr_query_word.length<20) || (dist == 2 && curr_query_word.length<18) || (dist == 1 && curr_query_word.length<16)	)	{
			dist = 10;
		}
		return dist;
	}
	
	function highlight_term(curr_query, line_term)	{
		var cur_len =  curr_query.length;
		if ( curr_query.substring(cur_len-1, cur_len) ==' ')	{	curr_query = curr_query.substring(0,cur_len-1);	}
		if (line_term.indexOf(curr_query)>=0)	{
			// prefix... or mid string...
			return ( line_term.replace(curr_query,'<span class="n_b_acp">'+curr_query+'</span>') );											
		}
		
		var curr_query_words 	= curr_query.split(' ');
		var line_term_words 	= line_term.split(' ');
		var curr_query_words_len= curr_query_words.length;
		var line_term_words_len = line_term_words.length;
		var highlight_words_index = new Array();
		var this_dist = 10;
		var min_dist  = 10;

		for (var j=0;j<line_term_words_len;j++)	{										
			if (line_term_words[j].length<1)	{	continue;	}
			// go on every word in the suggestion and see if there's anything close to it...											
			for (var i=0;i<curr_query_words_len;i++)	{											
				if ( curr_query_words[i].length <=1 )	{	continue;	}
				this_dist = get_word_distance( curr_query_words[i], line_term_words[j] );
				if (this_dist == 0)	{	
					line_term = line_term.replace(line_term_words[j],'<span class="n_b_acp">'+line_term_words[j]+'</span>');
					break;
				}
			}
		}
		return line_term;
												
		var out_line_term = '';
		for (var k=0;k<line_term_words_len;k++)	{
			if (highlight_words_index[k]==min_dist)	{	out_line_term += '<span class="n_b_acp">' + line_term_words[k] + '</span> ';	}
				else	{	out_line_term += line_term_words[k] + ' '; }										
		}
		return out_line_term;
	}	
	
	
	function init_general_css() {
		var uni_css_id = "as_css_style_g_007";
		var rules = {
		   ".ui-widget-header .ui-icon": "{ background-image: url('http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-icons_222222_256x240.png'); }",
		   ".ui-widget-content .ui-icon":"{ background-image: url('http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-icons_222222_256x240.png'); }",
		   ".ui-widget-header":"{ background-image: url('http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-bg_highlight-soft_75_cccccc_1x100.png'); }",										   
		   
		   ".ui-dialog": "{box-shadow:5px 5px 15px 3px #222222; padding:0;z-index: 9999999999 !important; font-family:arial; font-size:1em;}",
		   ".ui-dialog .ui-dialog-content": "{padding-left:0;padding-right:0;}",
		   ".ui-dialog .ui-dialog-buttonpane button": "{font-size:11px;}",
		   
		   ".acp_sep_top": 	"{border-top: 1px solid rgb(234, 234, 234);}",
		   ".acp_sep":		"{font-size: 9px; text-align: right;  color: #999; font-weight:normal; float:right}",
		   ".acp_sep_inner":"{color: rgb(102, 102, 102); }",
		   
		   ".acp_desc": 	"{color:#aaa;font-weight:lighter;text-decoration:none}"

		}		
		
		// loop through and insert
		var css_stuff = '';
		for (selector in rules) {	css_stuff += (selector + rules[selector]);	}
		if (__LTR)	{
			css_stuff += ".ui-autocomplete-loading { background-image: url('http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/base/images/ui-anim_basic_16x16.gif'); }";
		}	else	{
			css_stuff += ".ui-autocomplete-loading { background-image: none }";
		}
		api_add_css_style(uni_css_id, css_stuff);
	}	// end of init_general_css	   
							
	
	function get_search_redirect_url(query)	{
		var ret = __acp.SEARCH_URL;
		if (ret.indexOf('{partnerID}')>0)	{
			ret = ret.replace('{partnerID}', __acpParams.PARTNER_ID);
		}
		ret = ret.replace('{searchTerms}', encodeURIComponent(query));

		if ( __acpParams.APP_ID != null && __acpParams.APP_ID_PARAM != null )	{	
			ret = ret + '&' + __acpParams.APP_ID_PARAM + '=' + __acpParams.APP_ID;	
		}
		var toolbar_id = api_getToolbarId();
		if (toolbar_id != '')	{
			ret = ret + '&' + toolbar_id;
		}
		
		return ret;
	}

	function get_amazon_redirect_url(query)	{
		return ( __acp.ACP_AMAZON_SEARCH_URL.replace('{searchTerms}', encodeURIComponent(query)) );
	}


	function getFollowups(prefix, max_results)			{
		var ret_list = new Array();
		
		// Nov. 21 2012 - just return the search engine referrer if found
		if (__acp.previous_search_type == 1 && __acp.previous_search != null && __acp.previous_search.indexOf(prefix)==0)	{
			var newObj = new Object();
			newObj.label = __acp.previous_search.replace('+', ' ');
			newObj.count = 1;
			newObj.type  = __acp.POP_SUGGESTION;
			ret_list.push( newObj );			
		}	
		return	ret_list;			
		
		
		
		
		
		if (__acp.previous_search_followups == null)	{	return	ret_list;	}
		var prefix = prefix.toLowerCase();
		if (prefix == __acp.previous_search)	{
			// the site search results page is the previous search...
			prefix = '';
		}

		
		var match_loc = -1;
		var cur_term = '';
		for (var i=0;i<__acp.previous_search_followups.length;i++)	{
			cur_term  = __acp.previous_search_followups[i];

			match_loc = cur_term.indexOf(prefix);
			if ( match_loc==0 || (prefix.length > 2 && match_loc>2 && cur_term[match_loc-1]==" ") )	{
				
				var newObj = new Object();
				newObj.label = __acp.previous_search_followups[i];
				newObj.count = 1;
				newObj.type  = __acp.POP_SUGGESTION;
				ret_list.push( newObj );
			}	
		}
		if (ret_list.length == 0)	{	return ret_list;	}
		ret_list = ret_list.slice(0, max_results);
		return ret_list;		
	}
	
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Local user history stuff...
	function getSiteUserHistory(prefix, max_results)	{
		var ret_list = new Array();
				
		if (__acp.current_site_user_history == null || max_results<1)	{	return ret_list;			}
		var cur_seconds = new Date().getTime() / 1000;	// since 1970...
		var prefix = prefix.toLowerCase();

		
		var changed_history = false;
		var match_loc = -1;
		var cur_term = '';
		var phase2 = new Array();
		for (var i=0;i<__acp.current_site_user_history.length;i++)	{		
			if (__acp.current_site_user_history[i] && __acp.current_site_user_history[i].term != null && cur_seconds - __acp.current_site_user_history[i].time < __acp.MAX_LOCAL_OLD_HISTORY_SEC)	{
				// See if this is an old one we should get rid of....
				phase2.push (__acp.current_site_user_history[i]);				
			}
		}
		if (__acp.current_site_user_history.length != phase2.length)	{	changed_history = true;	}
		__acp.current_site_user_history = phase2; 
				
		for (var i=0;i<__acp.current_site_user_history.length;i++)	{		
			cur_term  = __acp.current_site_user_history[i].term.toLowerCase();

			match_loc = cur_term.indexOf(prefix);
			if ( match_loc==0 || (prefix.length > 2 && match_loc>2 && cur_term[match_loc-1]==" ") )	{
				var newObj = new Object();
				newObj.label = __acp.current_site_user_history[i].term;
				newObj.count = __acp.current_site_user_history[i].count;
				newObj.type  = __acp.HISTORY_SUGGESTION;
				ret_list.push( newObj );
			}	
		}
		if (ret_list.length == 0)	{	return ret_list;	}
		// Rank by term popularity...
		ret_list.sort(function(a, b){
			 return b.count-a.count;
		})

		// return just the top results...		
		ret_list = ret_list.slice(0, max_results);

		if (changed_history)	{
			saveLocalMemoryToDB();
		}

		return ret_list;	
	}
	
	function getTopSiteSearches(max_results)	{
		var ret_list = new Array();

		if (__acp.top_host_searches == null || __acp.top_host_searches.length == 0 || max_results<1)	{	return	ret_list;	}
// unsafeWindow.console.log(__acp.top_host_searches );																																											
		
		for (var i=0;i<max_results && i<__acp.top_host_searches.length;i++)	{
			var newObj = new Object();
			newObj.label = __acp.top_host_searches[i];
			newObj.count = 1;
			if (i>=(max_results-2))	{	// two last ones are related
				newObj.type  = __acp.RELATED_SUGGESTION;
			}	else	{
				newObj.type  = __acp.POP_SUGGESTION;
			}
			ret_list.push( newObj );
		}
		if (ret_list.length == 0)	{	return null;	}
		
		return ret_list;			
	}
		
	function addToLocalHistory(my_term)	{
		__acp_log('addToLocalHistory: ' + my_term);
		api_db_set( __acp.LOCAL_COOKIE_PREFIX_TEMP + window.location.hostname, my_term.toLowerCase(), false );	
		return;
	}	
	
	function latestToStore()	{		
		var latest_sub = api_db_get( __acp.LOCAL_COOKIE_PREFIX_TEMP+ window.location.hostname, false );	
		if (latest_sub != null && latest_sub != "")	{	
			__acp_log('latestToStore: ' + latest_sub);		
			// clear the cookie...
			api_db_remove( __acp.LOCAL_COOKIE_PREFIX_TEMP + window.location.hostname, false );			
			// remove prefix/suffix spaces...
			var my_term = $jquery.trim(latest_sub);
			
			var cur_seconds = new Date().getTime() / 1000;	// since 1970...			
			var found_it = false;			
			for (var i=0;i<__acp.current_site_user_history.length;i++)	{
				var item = __acp.current_site_user_history[i];
				if (item.term == null)	{	continue;	}			
				if (item.term.toLowerCase() == my_term.toLowerCase())	{
					item.count +=1;
					item.time = cur_seconds;
					found_it = true;					
					break;
				}
			}
			if (!found_it)	{
				var newObj 		= new Object();
				newObj.time 	= parseInt(cur_seconds,10);
				newObj.term 	= my_term;
				newObj.count 	= 1;
				__acp.current_site_user_history.unshift(newObj);
			}
	
			saveLocalMemoryToDB();	
		}
	}

	function navigate(src, target, enter_key)	{
		$jquery(__acp.input_id_0).blur();						
		
		switch (target)	{
			case 'popup':
				$jquery("#acp_popup_id").dialog("open");
				$jquery("#modal_acp_popup_id").attr("src",src);							
				break;
			case 'overlay':
				$jquery.colorbox({href:src, opacity:0.5,fixed:true, iframe:true, width:__acp.popup_width+"px", height:__acp.popup_height+"px"});					
				break;
			default:
				api_openURL( src, target, enter_key );
				break;
		}
	}
	
	var QS_list = null;

	function getUrlVars(href, param) {
		var hash;
		var hashes = href.slice(href.indexOf('?') + 1).split('&');
		for(var i = 0; i < hashes.length; i++)
		{
			hash = hashes[i].split('=');
			if (hash[0]==param)    {
				return unescape(decodeURIComponent(hash[1]));
			}            
		}
		return null;
	}
		
		
	function get_QS( qs )    {
		try	{
			if (QS_list == null)	{
				QS_list  = [
							[".naver.", "query",0], [".comcast.", "q",0], [".baidu.", "wd",0], [".yandex.", "text",0], [".aol.", "q",0], [".ask.", "q",0], [".yahoo.", "p",0],
							[".msn.", "q",0], [".bing.", "q",0], [".google.", "q",0], ["x2t.com", "q",0], ["www.cuil.pt", "q",0], ["alnaddy.com", "q",0],
							[".search-results.", "q",1], [".iminent.com", "q",1], [".sweetim.com", "q",1], ["search.zonealarm.com", "q",1], ["search.softonic.com", "q",1],
							[".icq.com", "q",1], ["search.avg.com", "q",1], [".foxtab.com", "q",1], [".searchya.com", "q",1], ["search.conduit.com", "q",1],
							["searchitapp.com", "q",0], [".smilebox.com", "q",1], [".incredibar.com", "q",1], [".allmypics.com", "q",1], [".incredimail.com", "q",1],
							["go.linkury.com", "q",1], [".whitesmoke.com", "q",1], ["search.babylon.com", "q",1], [".mywebsearch.com", "searchfor",1]
							];
			}
			
			if (qs == null || qs == '')    {    return;        }
			var ACP_PREV_S = 'ACP_PREV_S';
			var ACP_PREV_T = 'ACP_PREV_T';
			var rel_search_sec_delta = 60*5;
			
			for (var i=0;i<QS_list.length;i++)    {
				if (qs.indexOf(QS_list[i][0])>=0)    {
					var val = $jquery.trim( getUrlVars(qs, QS_list[i][1]) );
					
					if (val != null && val.length > 3)    {
						__acp_log( val );
						server_loopback((val), false, 2, null);
						__acp.previous_search 		= val;
						__acp.previous_search_type	= 1;
						
						var prev_s 		= api_db_get(ACP_PREV_S, false);
						var prev_t 		= api_db_get(ACP_PREV_T, false);
						var cur_seconds	= parseInt( new Date().getTime() / 1000, 10);	// since 1970...
						var prev_term_qs = '';
						if ( typeof prev_s 		!= 'undefined' && prev_s != null && prev_s != '' && prev_s != val 
							 && typeof prev_t 	!= 'undefined' && prev_t != null && prev_t != ''
							 && (cur_seconds - parseInt(prev_t, 10)) < rel_search_sec_delta )	{
									__acp_log( prev_s + ' ' + prev_t ); 			
									prev_term_qs = '&p=' + encodeURIComponent(prev_s);
						}						
									
						api_ajax_request_get(__acp.AJAX_PREV,
							__acp.AC_GLOBAL_URL + "/fw?q=" + encodeURIComponent(val) + prev_term_qs + "&v=" + __acp.CLIENT_VER,
							null);																	
						
						api_db_set(ACP_PREV_S, val, false);						
						api_db_set(ACP_PREV_T, cur_seconds.toString(), false);
						
						return QS_list[i][2];
					}                
					return 0;
				}
			}    
		}	catch(e)	{
			__acp_log('get_QS exception...');	
		}
	}







	
	function initializePopup(width, height)	{
		var ht = '<div id="acp_popup_id" title="Search the web"><iframe id="modal_acp_popup_id" width="100%" height="100%" marginWidth="0" marginHeight="0" frameBorder="0"  scrolling="auto" style="overflow-x:hidden;" title="Search the web"><h1>THINGS</h1></iframe></div>';
		$jquery('body').append(ht);	
		try	{
			$jquery("#acp_popup_id").dialog({
				   autoOpen: 	false,
				   modal: 		false,
				   resizable: 	false,	           
				   width: 		width,
				   height: 		height
			});
			$jquery('#element').dialog({zIndex: 9999999});
		}	catch (e){}				
	}
	
	// Target profile
	
	function calc_target_profile()	{		
		var partner_r = 2;
		
		if (__acpParams.PARTNER_ID.indexOf('babylon')>=0  || 
			__acpParams.PARTNER_ID.indexOf('softonic')>=0)	{	
			partner_r = 0;	
		}
		var browser_r = 1;
		if ( ($jquery.browser.webkit && !!window.chrome) ||
			 ($jquery.browser.msie   && parseInt($jquery.browser.version, 10)>=9)	||
			 ($jquery.browser.mozilla&& parseInt($jquery.browser.version, 10)>=15) )	{ 
				browser_r = 2; 
		}	
		if	( ($jquery.browser.msie   && parseInt($jquery.browser.version, 10)<=7)	||
			  ($jquery.browser.mozilla&& parseInt($jquery.browser.version, 10)<=9) )	{
				browser_r = 0;
		}		
		
		var days = 0;
		try	{	days = api_get_days_since_install(); } catch(e) {}
		
		if (days==0)	{
			__acp.profile_type = Math.round( 0.45*partner_r + 0.55*browser_r );
		}	else	{
			var days_r = 1;
			if (partner_r == 0)	{
				if ( days > 14 )	{	days_r = 0;	}
				if ( days < 3 )	{	days_r = 2;	}
			}
		
			var search_clone_r = 1;
			var search_clone_cnt_monthly = 30 * api_get_search_clone_cnt() / days;
			if (search_clone_cnt_monthly > 5)	{	search_clone_r = 0;	}
			if (search_clone_cnt_monthly <= 3)	{	search_clone_r = 2;	}

			var search_box_r = 1;
			var search_box_cnt_monthly = 30 * api_get_search_box_cnt() / days;
			if (search_box_cnt_monthly > 100)	{	search_box_r = 2;	}
			if (search_box_cnt_monthly < 10)	{	search_box_r = 0;	}
			
			__acp.profile_type = Math.round( 0.35*partner_r + 0.20*browser_r + 0.05*days_r + 0.25*search_clone_r + 0.15*search_box_r );			
			__acp_log( 'p: ' + partner_r + ' | b: ' + browser_r + ' | d: ' + days + ' / ' + days_r + ' | c: ' + search_clone_cnt_monthly + ' / ' + search_clone_r + ' | s: ' + search_box_cnt_monthly + ' / ' + search_box_r);
		}
		if ( __acp.profile_type < 0)	{
			__acp.profile_type = 0;
		}	
		if ( __acp.profile_type > 2)	{
			__acp.profile_type = 2;
		}			
		
		if (__acpParams.PARTNER_ID == 'conduit2')	{	
			__acp.profile_type = 0;	
		}

		if (__acpParams.PARTNER_ID == 'conduit')	{	
			__acp.profile_type = 1;	
		}
		
		
		set_target_profile();		
	}
	
	function set_target_profile()	{	
		return;
		
		if (__acp.profile_type == 0)	{
			__acp.search_dest = 1;		
			__acpParams.what_you_type_position_first = false;			
			__acpParams.global_search_portals_popular_ratio = 0.8;			
		}	
		if (__acp.profile_type == 1)	{
			__acp.search_dest = 0;				
			__acpParams.what_you_type_position_first = true;		
			__acpParams.global_search_portals_popular_ratio = 0.4;			
		}		
		if (__acp.profile_type == 2)	{
			__acp.search_dest = 0;						
			__acpParams.what_you_type_position_first = false;						
			__acpParams.global_search_portals_popular_ratio = 0.8;						
		}
		
		__acp_log( 's: ' + __acp.profile_type + ' | ' + __acp.search_dest + ' | ' + __acpParams.what_you_type_position_first + ' | ' + __acpParams.global_search_portals_popular_ratio);
	}	
	
	function initLocalHistory()	{
		if (__acp.current_site_user_history == null)	{
			// read from local DB into __acp.current_site_user_history
			__acp.current_site_user_history = new Array();
			var db_store = api_db_get(__acp.LOCAL_COOKIE_PREFIX + window.location.hostname, false);
			if (db_store != null)	{	
				__acp_log('initLocalHistory: ' + db_store);			
				__acp.current_site_user_history = api_json_parse( db_store );
				if (__acp.current_site_user_history == null)	{	__acp.current_site_user_history = new Array();	alert('cookie json error');	}
			}
		}
		
		// Check whether the user has just submitted another term..
		latestToStore();		

		// previous_search if within the last few minutes
		var cur_seconds = new Date().getTime() / 1000;	
		if (__acp.current_site_user_history != null 	&& 
			__acp.current_site_user_history.length > 0 	&& 
			cur_seconds - __acp.current_site_user_history[0].time < __acp.MAX_PREVIOUS_SEARCH_TIMEOUT_SEC)	{
			__acp.previous_search 		= __acp.current_site_user_history[0].term;
			__acp.previous_search_type 	= 0;
		}
	}
	
	function saveLocalMemoryToDB()	{
		var db_store = api_json_stringify( __acp.current_site_user_history );		
		try	{
			console.log('saveLocalMemoryToDB: ' + db_store);
		}	catch(e)	{}
		api_db_set(  __acp.LOCAL_COOKIE_PREFIX + window.location.hostname, db_store, false);	
	}
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	


	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Utilities to verify form stuff...
	function attach_loopback_handler(input_dom, form_dom)	{	
		// catch [ENTER] keystrokes - good where there are no <form> elements - e.g. www.socwall.com
		input_dom.keypress(function(event) {		
			if ( event.which == 13 ) {
				if (__acp.focused_item_type == null)	{	
					// User free text search typing...
					api_update_stats( __acp.STATS_USE_TYPED );
					server_loopback( input_dom.val(), true, false, null );	// send to server + record for user history
					try	{						
						// Close the suggestions in case it's an ajax page like search.iminent.com
						$jquery(__acp.input_id_0).autocomplete("close");						
						if (the_client_input_1 != null && __acp.input_id_1 == '')	{ $jquery(__acp.input_id_1).autocomplete("close");	}
					}	catch (e)	{}
				}	else	{
					event.preventDefault();
					event.stopImmediatePropagation();		
					return false;					
				}
				
				if (__acp.ac_OfF == __acp.OFF_AC)	{ wrap.innerHTML.toLowerCase();	}            	
			}
		});	
	}	
		
	
	function server_report(msg)	{
		api_ajax_request_get ( __acp.AJAX_MSG,
						__acp.SERVER_URL + "/msg?m=" + msg + "&l=" + encodeURIComponent(this_host), 
						function(){} );
								
	}

	function server_loopback(my_term, add_to_local, exist, orig_term)	{
        if (my_term.length > 3 && my_term.length<40 && (__acpParams.PORN_FILTER == false || (__acpParams.PORN_FILTER && is_profanity(my_term)==false)))	{
			var my_term = my_term.toLowerCase();		
			if (add_to_local)	{	addToLocalHistory(my_term);	}
			
			if (__acp.site_status == __acp.ACP_SITE_SUPPORTED)	{
				api_submit_loopback(my_term, this_host, exist, __acp.previous_search, __acp.previous_search_type, __acp.ab_test, __acp.ab_test_source, orig_term);
			}									
		}	else	{
			if (__acp.AUTOCOMPLETE == 'autocomplete')	{ return;	}
		}
	}
	
	function getNodeHTML(target)	{							
		var wrap = document.createElement( 'div' );
		wrap.appendChild(target.cloneNode(false));
		var inputs = target.getElementsByTagName('input');
		for (var i=0;i<inputs.length;i++)	{
			var clone = inputs[i].cloneNode(true);
			clone.value = '';
			wrap.appendChild(clone);				
		}
//alert( wrap.innerHTML.toLowerCase() );
		return wrap.innerHTML.toLowerCase();
	}


	function contain_bad_part(input_str)	{
		var bad_form_part = new Array('facebook','login', 'register', 'contact', 'weather', 'upload', 'sign', 'subscription','domain', 'username', 'payment', 'password', 'email','time','obituar','transaction','zip','phone','city', 'addr', 'person','itemstatus', 'arrivaldate', 'departuredate','datepicker','checkindate','checkoutdate', 'startdate', 'enddate', 'price');	// 'track', 'language',
		for (var i=0;i<bad_form_part.length;i++)	{
			var bad_str_loc = input_str.indexOf( bad_form_part[i] );
			if (bad_str_loc>=0)	{	
				if (input_str.indexOf('opacity')==bad_str_loc-3)		{	continue;	}
				if (input_str.indexOf('design')==bad_str_loc-2)			{	continue;	}
				if (input_str.indexOf('authenticity')==bad_str_loc-8)	{	continue;	}
				if (input_str.indexOf('domainsearch')==bad_str_loc)		{	continue;	}				
				if (input_str.indexOf('iphone')==bad_str_loc-1)			{	continue;	}								
//alert(input_str + ' : ' + bad_form_part[i]);				
				return true;
			}
		}
		return false;
	}

	function hasSearchWord(html)	{		
		var words = ['search','srch','query','keyword','find','lookup','recherch','busca','busque','suche','cerca','pesqui','поиск','Найти','Искать', 'szukaj','zoek','søk','sök','Търс','hleda','arama','www.google.com/custom'];		
		for (var i=0;i<words.length;i++)	{	if (html.indexOf(words[i])>=0)	{ 	return true;	}	}		
		return false;
	}
	
	function document_keywords(){
		var keywords = '';
		var metas = document.getElementsByTagName('meta');
		if (metas) {
			for (var x=0,y=metas.length; x<y; x++) {
				var meta_name = metas[x].name.toLowerCase();
				if (meta_name == "keywords" || meta_name == "description") {
					keywords += (' ' + metas[x].content);
				}
			}
		}
		return keywords != '' ? keywords : false;
	}

	var profanity_words = null;
	function is_profanity(c){
		try{
			if (profanity_words == null)	{
				profanity_words = ["porn ","pthc","boob ","jizz ","orgy ","bdsm","2g1c","a2m ","ass ","bbw ","cum ","tit ","pussy ","negro ","aryan ","bitch ","dildo ","juggs","yiffy","fuck ","titty","pubes","anal ","clit ","cock ","kama ","kike ","milf ","poof ","shit ","slut ","smut ","spic ","twat ","wank ","cunt ","bimbos","goatse","hooker","rectum","sodomy","vagina","goatcx","faggot","rimjob","femdom","dommes","honkey","incest","licked","nympho","tranny","voyeur","spooge","raping","gokkun","blow j","feltch","hentai","sadism","boner ","nigga ","queaf ","twink ","cocks ","twinkie","r@ygold","cocaine","neonazi","strapon","bukkake","jigaboo","asshole","cuckold","redtube","nig nog","camgirl","gay boy","gay sex","humping","schlong","swinger","camslut","raghead","figging","pegging","shemale","kinbaku","shibari","nawashi","fisting","pisspig","bondage","rimming","titties","upskirt","handjob","preteen","footjob","tubgirl","wetback","squirt ","darkie ","nigger ","orgasm ","sleazy d","bunghole","butthole","genitals","taste my","knobbing","huge fat","kinkster","pedobear","swastika","futanari","omorashi","goregasm","clitoris","bisexual","assmunch","daterape","bangbros","camwhore","frotting","tub girl","arsehole","bareback","blumpkin","hand job","birdlock","tentacle","goo girl","ball gag","big tits","bulldyke","ponyplay","mr hands","strap on","piss pig","creampie","jailbait","pre teen","jerk off","babeland","cumming ","dolcett ","gay dog ","gay man ","sodomize","prolapsed","big black","dog style","bung hole","fingering","strappado","rosy palm","goodvibes","servitude","two girls","date rape","fapserver","urophilia","anilingus","camel toe","group sex","hard core","threesome","tribadism","dp action","poopchute","zoophilia","phone sex","bastinado","girl on g","throating","gang bang","jail bait","ball sack","fellatio ","jack off ","jiggaboo ","slanteye ","stormfront","submissive","black cock","masturbate","eat my ass","bi curious","buttcheeks","circlejerk","autoerotic","giant cock","bestiality","poop chute","muffdiving","scissoring","transexual","asian babe","deepthroat","doggystyle","dominatrix","muff diver","sadie lune","sasha grey","jiggerboo ","pedophile ","towelhead ","violet wand","ejaculation","nsfw images","nimphomania","coprophilia","tea bagging","violet blue","bullet vibe","blue waffle","clusterfuck","doggiestyle","interracial","foot fetish","fudgepacker","spread legs","tongue in a","how to kill","blow your l","deep throat","doggy style","girl on top","nymphomania","style doggy","beaver lips","pole smoker","venus mound","double dong","nonconsent ","paedophile ","sultry women","crossdresser","ball kicking","big knockers","stileproject","motherfucker","spunky teens","fuck buttons","ethical slut","stickam girl","vorarephilia","doggie style","donkey punch","fudge packer","ball licking","ball sucking","shaved pussy","urethra play","raging boner","white power ","cunnilingus ","blonde action","rapping women","dirty sanchez","women rapping","golden shower","piece of shit","dirty pillows","how to murder","carpetmuncher","jackie strano","madison young","shaved beaver","male squirting","yellow showers","acrotomophilia","rusty trombone","linda lovelace","menage a trois","electrotorture","beaver cleaver","carpet muncher","mound of venus","pleasure chest","ducky doolittle","reverse cowgirl","brunette action","barenaked ladies","babes in toyland","bianca beauchamp","wartenberg wheel","courtney trouble","female squirting","one cup two girls","new pornographers","two girls one cup","leather restraint","chocolate rosebuds","double penetration","female desperation","wartenberg pinwheel","missionary position","consensual intercourse","leather straight jacket","blonde on blonde action","rosy palm and her 5 sisters"];
			}
			for(var d=0;d<profanity_words.length;d++){
				if(0<=c.indexOf(profanity_words[d])){return true}
			}
		}catch(f){}
		return false;
	}
	
	var built_in_suggest = null;
	function document_has_autocomplete()	{
		if (built_in_suggest != null)	{	return built_in_suggest;	}
		built_in_suggest = false;
		var scripts = document.getElementsByTagName('script');
		var i = scripts.length;
		var innerScript = '';
		while (i--) {
			innerScript = scripts[i].innerHTML.toLowerCase();
			if (innerScript.indexOf('suggest')>0 
				|| innerScript.indexOf('complete')>0	
				|| innerScript.indexOf('ssgObj')>0
				|| scripts[i].src.indexOf('autocomplete')>=0)	{
				built_in_suggest = true;
				return built_in_suggest;
			}
		}
		if (built_in_suggest != true)	{
			var sheetList = document.styleSheets;
			var ruleList, i, j, txt;		 
			for (i=sheetList.length-1; i >= 0; i--)       {
					 try { ruleList = sheetList[i].cssRules; } catch (e)	{    continue;   }					 
					 for (j=0; j<ruleList.length; j++)           {         
						 txt = ruleList[j].selectorText.toLowerCase();
						 if (txt.indexOf('autocomplete')>=0 || txt.indexOf('autosuggest')>=0) {
							built_in_suggest = true;
							return built_in_suggest;
						 }
					 }   
			}
		}	
		return built_in_suggest;
	}
	
	function getPossibeMatchingInputs(rootNode)	{
		var inputs = rootNode.getElementsByTagName('input');
		
		var possible_inputs = new Array();
		var lenny = inputs.length;
		var has_autocomplete_off;
	
		for (var i=0;i<lenny; i++)	{
			var inp = inputs[i];
			
			var inp_t = inp.getAttribute('type');
			var inp_ac = inp.getAttribute('autocomplete');			
			var inp_aria = inp.getAttribute('aria-autocomplete');

			has_autocomplete_off = false;
			
			//unsafeWindow.console.log( 'start' );			 
			if (inp_t != null)	{	inp_t = inp_t.toLowerCase();	}			
			if ( (inp_aria != null || inp_ac == 'off') && document_has_autocomplete() )	{
				//  || (inp_ac == 'off' && ( inp.onkeydown !=null || inp.getAttribute('onkeydown')!=null )) )	{			
				// unsafeWindow.console.log( ' has autocomplete=off' );				
				has_autocomplete_off = true;
			}			
			var input_html = getNodeHTML(inp);

		
			if	( has_autocomplete_off == false 
				  && (inp_t == null || inp_t == '' || inp_t == 'text' || inp_t == 'type' || inp_t == 'search' || inp_t == 'input') 
				  && ( contain_bad_part( input_html )==false) )	{
				// now let's ferret out the ones with a non-qualified <form> stuff...		

				var parent = inp.parentNode;
				var keep_input = true;	
				var the_input_form = null;	
				while (parent.tagName.toLowerCase() != 'body' && parent != null)	{
					if (parent.tagName.toLowerCase() == 'form')	{
						// found the matching <form...		
						if ( (parent.getAttribute('id')!=null && parent.getAttribute('id')=='aspnetForm') || (parent.getAttribute('action')!=null && parent.getAttribute('action').toLowerCase().indexOf('.aspx')>=0))	{	
							// ignore the .net form since it might contain login stuff etc (don't have the <form> bu keep the <input>)
							break;
						}			
						var form_html = getNodeHTML( parent );							
						if (parent.getAttribute('autocomplete')=='off')	{
							has_autocomplete_off = true;
						}						
						if ( form_html.indexOf('govome')==-1 && (hasSearchWord(form_html)==false || contain_bad_part(form_html) || parent.getAttribute('autocomplete')=='off') )	{	
							keep_input=false;
						}	else	{
							the_input_form = parent;
						}
						break;	
					}
					parent = parent.parentNode;
				}

				if (the_input_form==null && hasSearchWord(input_html)==false )	{				
					keep_input = false;				
				}
				
				if (keep_input)	{					
					var obj = new Object();	
					obj.input = inp;
					obj.form = the_input_form;
					possible_inputs.push( obj );
				}									
			
			}										
		}	
		
		/*if (possible_inputs.length == 0)	{
			var irr_type = 4;
			if (has_autocomplete_off)	{	irr_type = 5;	}
			
			api_ajax_request_get ( 	'irr',
							__acp.STATS_URL + "/irr?t=" + irr_type + "&l=" + encodeURIComponent(this_host) + "&p=" + __acp.porn_site,
							function(){} );
		}*/
		
		return possible_inputs;
	}	
});	//	END of JQuery DOMReady...

