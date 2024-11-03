// Biến khởi tạo
var timeOut_modalCart;
var viewout = true;
var check_show_modal = true;
// Add a product and show modal cart
var add_item_show_modalCart = function (id, link_checkout) {
	if (check_show_modal) {
		check_show_modal = false;
		timeOut_modalCart = setTimeout(function () {
			check_show_modal = true;
		}, 1000);
		if ($('.addtocart-modal').hasClass('clicked_buy')) {
			var quantity = $('#quantity').val();
		} else {
			var quantity = 1;
		}
		var params = {
			type: 'POST',
			url: '/cart/add.js',
			async: false,
			data: 'quantity=' + quantity + '&id=' + id,
			dataType: 'json',
			success: function (line_item) {
				if (link_checkout != undefined) {
					window.location = "/checkout";
				}
				else {
					getCartModal();
					jQuery('#myCart').modal('show');
					jQuery('.modal-backdrop').css({ 'height': jQuery(document).height(), 'z-index': '99' });
				}
				$('.addtocart-modal').removeClass('clicked_buy');
			},
			error: function (XMLHttpRequest, textStatus) {
				alert('Sản phẩm bạn vừa mua đã vượt quá tồn kho');
			}
		};
		jQuery.ajax(params);
	}
}
// Plus number quantiy product detail 
var plusQuantity = function () {
	if (jQuery('input[name="quantity"]').val() != undefined) {
		var currentVal = parseInt(jQuery('input[name="quantity"]').val());
		if (!isNaN(currentVal)) {
			jQuery('input[name="quantity"]').val(currentVal + 1);
		} else {
			jQuery('input[name="quantity"]').val(1);
		}
	} else {
		console.log('error: Not see elemnt ' + jQuery('input[name="quantity"]').val());
	}
}
// Minus number quantiy product detail 
var minusQuantity = function () {
	if (jQuery('input[name="quantity"]').val() != undefined) {
		var currentVal = parseInt(jQuery('input[name="quantity"]').val());
		if (!isNaN(currentVal) && currentVal > 1) {
			jQuery('input[name="quantity"]').val(currentVal - 1);
		}
	} else {
		console.log('error: Not see elemnt ' + jQuery('input[name="quantity"]').val());
	}
}
// Modal Cart
function getCartModal() {
	var cart = null;
	jQuery('#cartform').hide();
	jQuery('#myCart #exampleModalLabel').text("Giỏ hàng");
	jQuery.getJSON('/cart.js', function (cart, textStatus) {
		if (cart) {
			jQuery('#cartform').show();
			jQuery('.line-item:not(.original)').remove();
			jQuery.each(cart.items, function (i, item) {
				var total_line = 0;
				var total_line = item.quantity * item.price;
				tr = jQuery('.original').clone().removeClass('original').appendTo('table#cart-table tbody');
				if (item.image != null)
					tr.find('.item-image').html("<img src=" + Haravan.resizeImage(item.image, 'small') + ">");
				else
					tr.find('.item-image').html("<img src='//theme.hstatic.net/200000104195/1000677830/14/no_image.jpg?v=387'>");
				vt = item.variant_options;
				if (vt.indexOf('Default Title') != -1)
					vt = '';
				tr.find('.item-title').children('a').html(item.product_title + '<br><span>' + vt + '</span>').attr('href', item.url);
				tr.find('.item-quantity').html("<input id='quantity1' name='updates[]' min='1' type='number' value=" + item.quantity + " class='' />");
				if (typeof (formatMoney) != 'undefined') {
					tr.find('.item-price').html(Haravan.formatMoney(total_line, formatMoney));
				} else {
					tr.find('.item-price').html(Haravan.formatMoney(total_line, ''));
				}
				tr.find('.item-delete').html("<a href='javascript:void(0);' onclick='deleteCart(" + (i + 1) + ")' ><i class='fa fa-times'></i></a>");
			});
			jQuery('.item-total').html(Haravan.formatMoney(cart.total_price, formatMoney));
			jQuery('.modal-title').children('b').html(cart.item_count);
			jQuery('.count-holder .count').html(cart.item_count);
			if (cart.item_count == 0) {
				jQuery('#exampleModalLabel').html('Giỏ hàng của bạn đang trống. Mời bạn tiếp tục mua hàng.');
				jQuery('#cart-view').html('<tr class="item-cart_empty"><td><div class="svgico-mini-cart"> <svg width="81" height="70" viewBox="0 0 81 70"><g transform="translate(0 2)" stroke-width="4" stroke="#1e2d7d" fill="none" fill-rule="evenodd"><circle stroke-linecap="square" cx="34" cy="60" r="6"></circle><circle stroke-linecap="square" cx="67" cy="60" r="6"></circle><path d="M22.9360352 15h54.8070373l-4.3391876 30H30.3387146L19.6676025 0H.99560547"></path></g></svg></div> Hiện chưa có sản phẩm</td></tr>');
				jQuery('#cartform').hide();
			}
			else {
				jQuery('#exampleModalLabel').html('Bạn có ' + cart.item_count + ' sản phẩm trong giỏ hàng.');
				jQuery('#cartform').removeClass('hidden');
				jQuery('#cart-view').html('');
			}
			if (jQuery('#cart-pos-product').length > 0) {
				jQuery('#cart-pos-product span').html(cart.item_count + ' sản phẩm');
			}
			// Get product for cart view
			jQuery.each(cart.items, function (i, item) {
				clone_item(item, i);
			});
			jQuery('#total-view-cart').html(Haravan.formatMoney(cart.total_price, formatMoney));
		}
		else {
			jQuery('#exampleModalLabel').html('Giỏ hàng của bạn đang trống. Mời bạn tiếp tục mua hàng.');
			if (jQuery('#cart-pos-product').length > 0) {
				jQuery('#cart-pos-product span').html(cart.item_count + ' sản phẩm');
			}
			jQuery('#cart-view').html('<tr class="item-cart_empty"><td><div class="svgico-mini-cart"> <svg width="81" height="70" viewBox="0 0 81 70"><g transform="translate(0 2)" stroke-width="4" stroke="#1e2d7d" fill="none" fill-rule="evenodd"><circle stroke-linecap="square" cx="34" cy="60" r="6"></circle><circle stroke-linecap="square" cx="67" cy="60" r="6"></circle><path d="M22.9360352 15h54.8070373l-4.3391876 30H30.3387146L19.6676025 0H.99560547"></path></g></svg></div> Hiện chưa có sản phẩm</td></tr>');
			jQuery('#cartform').hide();
		}
	});
	if (!$('.header-action_cart').hasClass('show-action')) {
		$('body').removeClass("locked-scroll");
		$('.header-action').removeClass('show-action');
	}
	if ($('#site-header').hasClass('hSticky')) {
		$('#site-header').addClass("hSticky-nav");
		setTimeout(function () {
			$('#site-header').addClass("hSticky-up");
		}, 300);
		setTimeout(function () {
			$('.header-action_cart').addClass("show-action");
			$('body').addClass("locked-scroll");
		}, 500);
	}
	else {
		$('.header-action_cart').addClass("show-action");
		$('body').addClass("locked-scroll");
		jQuery('html, body').animate({
			scrollTop: 0
		}, 600);
	}
}
//clone item cart
function clone_item(product, i) {
	var item_product = jQuery('#clone-item-cart').find('.item_2');
	if (product.image == null) {
		item_product.find('img').attr('src', '//theme.hstatic.net/200000104195/1000677830/14/no_image.jpg?v=387').attr('alt', product.url);
	} else {
		item_product.find('img').attr('src', Haravan.resizeImage(product.image, 'small')).attr('alt', product.url);
	}
	item_product.find('a:not(.remove-cart)').attr('href', product.url).attr('title', product.url);
	item_product.find('.pro-title-view').html(product.title);
	item_product.find('.pro-quantity-view .qty-value').html(product.quantity);
	item_product.find('.pro-price-view').html(Haravan.formatMoney(product.price, formatMoney));
	item_product.find('.remove-cart').html('<a href="javascript:void(0);" onclick="deleteCart(' + (i + 1) + ')" ><svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 1000 1000" enable-background="new 0 0 1000 1000" xml:space="preserve"> <g><path d="M500,442.7L79.3,22.6C63.4,6.7,37.7,6.7,21.9,22.5C6.1,38.3,6.1,64,22,79.9L442.6,500L22,920.1C6,936,6.1,961.6,21.9,977.5c15.8,15.8,41.6,15.8,57.4-0.1L500,557.3l420.7,420.1c16,15.9,41.6,15.9,57.4,0.1c15.8-15.8,15.8-41.5-0.1-57.4L557.4,500L978,79.9c16-15.9,15.9-41.5,0.1-57.4c-15.8-15.8-41.6-15.8-57.4,0.1L500,442.7L500,442.7z"/></g> </svg></a>');
	var title = '';
	if (product.variant_options.indexOf('Default Title') == -1) {
		$.each(product.variant_options, function (i, v) {
			title = title + v + ' / ';
		});
		title = title + '@@';
		title = title.replace(' / @@', '')
		item_product.find('.variant').html(title);
	} else {
		item_product.find('.variant').html('');
	}
	item_product.clone().removeClass('hidden').prependTo('#cart-view');
}
// Delete variant in modalCart
function deleteCart(line) {
	var params = {
		type: 'POST',
		url: '/cart/change.js',
		data: 'quantity=0&line=' + line,
		dataType: 'json',
		success: function (cart) {
			getCartModal();
		},
		error: function (XMLHttpRequest, textStatus) {
			Haravan.onError(XMLHttpRequest, textStatus);
		}
	};
	jQuery.ajax(params);
}
// Buynow
var buy_now = function (id) {
	var quantity = 1;
	var params = {
		type: 'POST',
		url: '/cart/add.js',
		data: 'quantity=' + quantity + '&id=' + id,
		dataType: 'json',
		success: function (line_item) {
			window.location = '/checkout';
		},
		error: function (XMLHttpRequest, textStatus) {
			Haravan.onError(XMLHttpRequest, textStatus);
		}
	};
	jQuery.ajax(params);
}
// Update product in modalCart
jQuery(document).on("click", "#update-cart-modal", function (event) {
	event.preventDefault();
	if (jQuery('#cartform').serialize().length <= 5) return;
	jQuery(this).html('Đang cập nhật');
	var params = {
		type: 'POST',
		url: '/cart/update.js',
		data: jQuery('#cartform').serialize(),
		dataType: 'json',
		success: function (cart) {
			if ((typeof callback) === 'function') {
				callback(cart);
			} else {
				getCartModal();
			}
			jQuery('#update-cart-modal').html('Cập nhật');
		},
		error: function (XMLHttpRequest, textStatus) {
			Haravan.onError(XMLHttpRequest, textStatus);
		}
	};
	jQuery.ajax(params);
});
/* fixHeightProduct */
function fixHeightProduct(data_parent, data_target, data_image) {
	var box_height = 0;
	var box_image = 0;
	var boxtarget = data_parent + ' ' + data_target;
	var boximg = data_parent + ' ' + data_target + ' ' + data_image;
	jQuery(boximg).css('height', 'auto');
	jQuery($(boxtarget)).css('height', 'auto');
	jQuery($(boxtarget)).removeClass('fixheight');
	jQuery($(boxtarget)).each(function () {
		if (jQuery(this).find(data_image + ' .lazyloaded').height() > box_image) {
			box_image = jQuery(this).find($(data_image)).height();
		}
	});
	if (box_image > 0) {
		jQuery(boximg).height(box_image);
	}
	jQuery($(boxtarget)).each(function () {
		if (jQuery(this).height() > box_height) {
			box_height = jQuery(this).height();
		}
	});
	jQuery($(boxtarget)).addClass('fixheight');
	if (box_height > 0) {
		jQuery($(boxtarget)).height(box_height);
	}
	try {
		fixheightcallback();
	} catch (ex) { }
}
// Image Product Loaded fix height
$(document).on('lazyloaded', function (e) {	//lazybeforeunveil 
	fixHeightProduct('.wrapper-collection-1 .content-product-list', '.product-resize', '.image-resize');
	if (jQuery(window).width() > 991) {
		jQuery(window).resize(function () {
			fixHeightProduct('.wrapper-collection-1 .content-product-list', '.product-resize', '.image-resize');
		});
	}
	fixHeightProduct('.wrapper-collection-2 .content-product-list', '.product-resize', '.image-resize');
	if (jQuery(window).width() > 991) {
		jQuery(window).resize(function () {
			fixHeightProduct('.wrapper-collection-2 .content-product-list', '.product-resize', '.image-resize');
		});
	}
	fixHeightProduct('#collection-body .content-product-list', '.product-resize', '.image-resize');
	jQuery(window).resize(function () {
		fixHeightProduct('#collection-body .content-product-list', '.product-resize', '.image-resize');
	});
	fixHeightProduct('.list-productRelated .content-product-list', '.product-resize', '.image-resize');
	jQuery(window).resize(function () {
		fixHeightProduct('.list-productRelated .content-product-list', '.product-resize', '.image-resize');
	});
	fixHeightProduct('.search-list-results', '.product-resize', '.image-resize');
	jQuery(window).resize(function () {
		fixHeightProduct('.search-list-results', '.product-resize', '.image-resize');
	});
});
function smoothScroll(a, b) {
	$('body,html').animate({
		scrollTop: a
	}, b);
}
function boxAccount(type) {
	$('.site_account .js-link').removeClass('is-selected');
	$(`.site_account .js-link[aria-controls="${type}"]`).addClass('is-selected');
	$('.site_account .site_account_panel_list .site_account_panel ').addClass('d-none');
	$('.site_account .site_account_panel_list .site_account_panel ').removeClass('is-selected');
	$(`.site_account .site_account_panel_list .site_account_panel#${type}`).removeClass('d-none');
	$(`.site_account .site_account_panel_list .site_account_panel#${type}`).addClass('is-selected');
	var newheight = $(`.site_account .site_account_panel_list .site_account_panel#${type}`).addClass('is-selected').height();
	if ($('.site_account_panel').hasClass('is-selected')) {
		$('.site_account_panel_list').css("height", newheight);
	}
};
jQuery(document).ready(function () {
	// Get number item for cart header
	$.get('/cart.js').done(function (cart) {
		$('.cart-menu .count').html(cart.item_count);
	});
	if (window.template.indexOf('index') > -1) {
		$('#home-slider .owl-carousel').owlCarousel({
			items: 1,
			nav: false,
			dots: true,
			touchDrag: true,
			lazyLoad: true,
			responsive: {
				0: {
					items: 1
				},
				768: {
					items: 1
				},
				1024: {
					items: 1
				}
			},
			onChanged: function (event) {
				setTimeout(function () {
					$('#home-slider .owl-carousel').find('.owl-dot').each(function (index) {
						$(this).attr('aria-label', index + 1);
					});
				}, 400);
			}
		});
		if ($('.list-slider-banner').length > 0) {
			var checkBanner = $('.list-slider-banner .home-banner-pd').length;
			$('.list-slider-banner').owlCarousel({
				items: 1,
				loop: true,
				dots: false,
				nav: false,
				smartSpeed: 1000,
				responsive: {
					0: {
						items: 1,
						stagePadding: 30,
					},
					480: {
						items: 1,
						stagePadding: 50,
					},
					768: {
						items: 2,
						stagePadding: 60,
						nav: true
					},
					992: {
						items: 3,
						stagePadding: checkBanner > 3 ? 90 : 0,
						loop: checkBanner > 3 ? true : false,
						nav: checkBanner > 3 ? true : false,
						mouseDrag: checkBanner > 3 ? true : false,
						touchDrag: checkBanner > 3 ? true : false
					},
					1200: {
						items: 3,
						stagePadding: checkBanner > 3 ? 60 : 0,
						loop: checkBanner > 3 ? true : false,
						nav: checkBanner > 3 ? true : false,
						mouseDrag: checkBanner > 3 ? true : false,
						touchDrag: checkBanner > 3 ? true : false
					}
				}
			});
		}
	}
	//Click event to scroll to top
	jQuery(document).on("click", ".back-to-top", function () {
		jQuery(this).removeClass('show');
		jQuery('html, body').animate({
			scrollTop: 0
		}, 800);
	});

	/* scroll header */
	var $parentHeader = $('.mainHeader--height');
	var parentHeight = $parentHeader.find('.main-header').outerHeight();

	var $header = $('.main-header');
	var offset_sticky_header = $header.outerHeight() + 150;
	var offset_sticky_down = 0;

	$parentHeader.css('min-height', parentHeight);
	var resizeTimer = false,
		resizeWindow = $(window).prop("innerWidth");
	if ($(window).width() > 992) {
		$(window).on("resize", function () {
			clearTimeout(resizeTimer);
			resizeTimer = setTimeout(function () {
				var newWidth = $(window).prop("innerWidth");
				if (resizeWindow != newWidth) {
					$header.removeClass('hSticky-up').removeClass('hSticky-nav').removeClass('hSticky');
					$parentHeader.css('min-height', '');
					parentHeight = $parentHeader.find('.main-header').outerHeight();
					$parentHeader.css('min-height', parentHeight);
					resizeWindow = newWidth;
				}
			}, 200)
		});
		setTimeout(function () {
			$parentHeader.css('min-height', '');
			parentHeight = $parentHeader.find('.main-header').outerHeight();
			$parentHeader.css('min-height', parentHeight);
			jQuery(window).scroll(function () {
				/* scroll header */
				if (jQuery(window).scrollTop() > offset_sticky_header && jQuery(window).scrollTop() > offset_sticky_down) {
					if (jQuery(window).width() > 991) {
						$('body').removeClass('locked-scroll');
						$('.header-action').removeClass('show-action');
					}
					$header.addClass('hSticky');
					if (jQuery(window).scrollTop() > offset_sticky_header + 150) {
						$header.removeClass('hSticky-up').addClass('hSticky-nav');
					}
				}
				else {
					if (jQuery(window).scrollTop() > offset_sticky_header + 150 && (jQuery(window).scrollTop() - 150) + jQuery(window).height() < $(document).height()) {
						$header.addClass('hSticky-up');
					}
				}
				if (jQuery(window).scrollTop() <= offset_sticky_down && jQuery(window).scrollTop() <= offset_sticky_header) {
					$header.removeClass('hSticky-up').removeClass('hSticky-nav');
					if (jQuery(window).scrollTop() <= offset_sticky_header - 100) {
						$header.removeClass('hSticky');
					}
				}
				offset_sticky_down = jQuery(window).scrollTop();
			});
		}, 300);
	}
	jQuery(window).scroll(function () {
		/* scroll top */
		if (jQuery('.back-to-top').length > 0 && jQuery(window).scrollTop() > 500) {
			jQuery('.back-to-top').addClass('show');
		} else {
			jQuery('.back-to-top').removeClass('show');
		}
	});
	/* backto - product */
	if ($('#backto-page').length > 0) {
		$(document).on("click", "#backto-page", function () {
			window.history.back();
		});
	}
	$('a[data-spy=scroll]').click(function () {
		event.preventDefault();
		$('body').animate({ scrollTop: ($($(this).attr('href')).offset().top - 20) + 'px' }, 500);
	})
	/* CLICK icon header */
	$('body').on('click', '.js-link', function (e) {
		e.preventDefault();
		boxAccount($(this).attr('aria-controls'));
	});
	$('.site_account input').blur(function () {
		var tmpval = $(this).val();
		if (tmpval == '') {
			$(this).removeClass('is-filled');
		} else {
			$(this).addClass('is-filled');
		}
	});
	$('.header-action-toggle').click(function (e) {
		e.preventDefault();
		if ($(this).parents('.header-action').hasClass('show-action')) {
			$('body').removeClass('locked-scroll');
			$(this).parents('.header-action').removeClass('show-action');
		}
		else {
			$('.header-action').removeClass('show-action');
			$('body').addClass('locked-scroll');
			$(this).parents('.header-action').addClass('show-action');
		}
	});
	$('body').on('click', '#site-overlay', function (e) {
		$('body').removeClass('locked-scroll');
		$('.header-action').removeClass('show-action');
	});
	/* mainmenu mobile */
	$('.list-root li a').click(function (e) {
		if ($(this).find('i').length) {
			e.preventDefault();
			var menu_child_id = $(this).parent().data('menu-root');
			$('.list-root').addClass('mm-subopened');
			$('#' + menu_child_id).addClass('mm-opened');
		}
	})
	$('.list-child li:first-child a').click(function () {
		$(this).parents('.list-child').removeClass('mm-opened');
		$('.list-root').removeClass('mm-subopened');
	})
	$('.list-child li.level-2 a').click(function (e) {
		if ($(this).find('i').length) {
			e.preventDefault();
			var menu_sub_id = $(this).parent().data('menu-root');
			$('li.level-2').addClass('mm-subopened');
			$('#' + menu_sub_id).addClass('mm-sub');
		}
	})
	$('.sub-child li:first-child a').click(function () {
		$(this).parents('.sub-child').removeClass('mm-sub');
		$('.list-child').removeClass('mm-subopened');
	})
	$(document).on("click", ".sub-child li.level-3 a", function (e) {
		if ($(this).find('i').length) {
			e.preventDefault();
			var menu_subnav_id = $(this).parent().data('menu-root');
			$('li.level-3').addClass('mm-open-3');
			$('#' + menu_subnav_id).addClass('mm-sub-3');
		}
	});
	$(document).on("click", ".sub-child-3 li:first-child a", function (e) {
		$(this).parents('.sub-child-3').removeClass('mm-sub-3');
		$('.sub-child').removeClass('mm-open-3');
	});
	// Dropdown Title
	jQuery('.title_block').click(function () {
		$(this).next().slideToggle('medium');
	});
	$(document).on("click", ".dropdown-filter", function () {
		if ($(this).parent().attr('aria-expanded') == 'false') {
			$(this).parent().attr('aria-expanded', 'true');
		} else {
			$(this).parent().attr('aria-expanded', 'false');
		}
	});
	// Mainmenu sidebar
	$(document).on("click", "span.icon-subnav", function () {
		if ($(this).parent().hasClass('active')) {
			$(this).parent().removeClass('active');
			$(this).siblings('ul').slideUp();
		} else {
			if ($(this).parent().hasClass("level0") || $(this).parent().hasClass("level1")) {
				$(this).parent().siblings().find("ul").slideUp();
				$(this).parent().siblings().removeClass("active");
			}
			$(this).parent().addClass('active');
			$(this).siblings('ul').slideDown();
		}
	});
	// Menu sidebar
	$(document).on('click', '.tree-menu .tree-menu-lv1', function () {
		$this = $(this).find('.tree-menu-sub');
		$('.tree-menu .has-child .tree-menu-sub').not($this).slideUp('fast');
		$(this).find('.tree-menu-sub').slideToggle('fast');
		$(this).toggleClass('menu-collapsed');
		$(this).toggleClass('menu-uncollapsed');
		var $this1 = $(this);
		$('.tree-menu .has-child').not($this1).removeClass('menu-uncollapsed');
	});
	/* footer */
	if (jQuery(window).width() < 768) {
		jQuery('.main-footer .footer-col .footer-title').on('click', function () {
			jQuery(this).toggleClass('active').parent().find('.footer-content').stop().slideToggle('medium');
		});
		// icon Footer
		$('a.btn-fter').click(function (e) {
			if ($(this).attr('aria-expanded') == 'false') {
				e.preventDefault();
				$(this).attr('aria-expanded', 'true');
				$('.main-footer').addClass('bg-active');
			} else {
				$(this).attr('aria-expanded', 'false');
				$('.main-footer').removeClass('bg-active');
			}
		});
	}
});

/* Search ultimate destop -mobile*/
$('.ultimate-search').submit(function (e) {
	e.preventDefault();
	var q = $(this).find('input[name=q]').val();
	if (q.indexOf('script') > -1 || q.indexOf('>') > -1) {
		alert('Từ khóa của bạn có chứa mã độc hại ! Vui lòng nhập lại key word khác');
		$(this).find('input[name=q]').val('');
	} else {
		var q_follow = 'product';
		var query = encodeURIComponent(q);
		if (!q) {
			window.location = '/search?type=' + q_follow + '&q=';
			return;
		}
		else {
			window.location = '/search?type=' + q_follow + '&q=' + query;
			return;
		}
	}
});
var $input = $('.ultimate-search input[type="text"]');
$input.bind('keyup change paste propertychange', function () {
	var key = $(this).val(),
		$parent = $(this).parents('.wpo-wrapper-search'),
		$results = $(this).parents('.wpo-wrapper-search').find('.smart-search-wrapper');
	if (key.indexOf('script') > -1 || key.indexOf('>') > -1) {
		alert('Từ khóa của bạn có chứa mã độc hại ! Vui lòng nhập lại key word khác');
		$(this).val('');
		$('.ultimate-search input[type="text"]').val('');
	}
	else {
		if (key.length > 0) {
			$('.ultimate-search input[type="text"]').val($(this).val());
			$(this).attr('data-history', key);
			var q_follow = 'product',
				str = '';
			str = '/search?type=product&q=' + key + '&view=ultimate-product';
			$.ajax({
				url: str,
				type: 'GET',
				async: true,
				success: function (data) {
					$results.find('.resultsContent').html(data);
				}
			})
			if (!$('.header-action_search').hasClass('show-action')) {
				$('body').removeClass("locked-scroll");
				$('.header-action').removeClass('show-action');
			}
			$(".search-bar-mobile .ultimate-search").addClass("expanded");
			$results.fadeIn();
		}
		else {
			$('.ultimate-search input[type="text"]').val($(this).val());
			$(".search-bar-mobile .ultimate-search").removeClass("expanded");
			$results.fadeOut();
		}
	}
})
$('body').click(function (evt) {
	var target = evt.target;
	if (target.id !== 'ajaxSearchResults' && target.id !== 'inputSearchAuto') {
		$(".ajaxSearchResults").hide();
	}
	if (target.id !== 'ajaxSearchResults-3' && target.id !== 'inputSearchAuto-3') {
		$("#ajaxSearchResults-3").hide();
	}
	if (target.id !== 'ajaxSearchResults-mb' && target.id !== 'inputSearchAuto-mb') {
		$(".ajaxSearchResults").hide();
	}
});
$('body').on('click', '.ultimate-search input[type="text"]', function () {
	if ($(this).is(":focus")) {
		if ($(this).val() != '') {
			$(".ajaxSearchResults").show();
		}
	} else {

	}
})
$('body').on('click', '.ultimate-search .close-search', function (e) {
	e.preventDefault();
	$(".ajaxSearchResults").hide();
	$(".ultimate-search").removeClass("expanded");
	$(".ultimate-search").find('input[name=q]').val('');
})
/*=======================================*/
jQuery(document).ready(function () {
	if ($('.addThis_listSharing').length > 0) {
		$(window).scroll(function () {
			if (jQuery(window).scrollTop() > 100) {
				jQuery('.addThis_listSharing').addClass('is-show');
			} else {
				jQuery('.addThis_listSharing').removeClass('is-show');
			}
		});
		$('.content_popupform form.contact-form').submit(function (e) {
			e.preventDefault();
			$.ajax({
				type: 'POST',
				url: '/contact',
				data: $('.content_popupform form.contact-form').serialize(),
				success: function (data) {
					$('.modal-contactform.fade.in').modal('hide');
					setTimeout(function () {
						$('.modal-succesform').modal('show');
						setTimeout(function () {
							$('.modal-succesform.fade.in').modal('hide');
						}, 5000);
					}, 300);
				}
			})
		});
		$(".modal-succesform").on('hidden.bs.modal', function () {
			location.reload();
		});
	}
	if ($('.layoutProduct_scroll').length > 0 && jQuery(window).width() < 768) {
		var curScrollTop = 0;
		$(window).scroll(function () {
			var scrollTop = $(window).scrollTop();
			if (scrollTop > curScrollTop && scrollTop > 200) {
				$('.layoutProduct_scroll').removeClass('scroll-down').addClass('scroll-up');
			}
			else {
				if (scrollTop > 200 && scrollTop + $(window).height() + 150 < $(document).height()) {
					$('.layoutProduct_scroll').removeClass('scroll-up').addClass('scroll-down');
				}
			}
			if (scrollTop < curScrollTop && scrollTop < 200) {
				$('.layoutProduct_scroll').removeClass('scroll-up').removeClass('scroll-down');
			}
			curScrollTop = scrollTop;
		});
	}
});
if ($(window).width() < 991) {
	$('.mainContent-theme').css('margin-top', $('.mainHeader--height').height());
}
$('.block-bar-menu').click(function (e) {
	$('body').addClass('f-overflow');
})
$('.btn-close-menu').click(function (e) {
	$('body').removeClass('f-overflow');
})
$('.mb-menu li.has-sub > a .toggle-menu-child').click(function (e) {
	e.preventDefault();
	$(this).toggleClass('active');
	$(this).parent().siblings().slideToggle();
})

function getValueFromDropDownList() {
	var select = document.getElementById('valueDropDownList');
	var text = select.options[select.selectedIndex].text;
	console.log(text); // English
}