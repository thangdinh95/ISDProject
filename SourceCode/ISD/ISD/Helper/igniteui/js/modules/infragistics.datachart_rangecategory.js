﻿/*!@license
* Infragistics.Web.ClientUI infragistics.datachart_rangecategory.js 16.2.20162.2040
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
* Depends:
*     jquery-1.4.4.js
*     jquery.ui.core.js
*     jquery.ui.widget.js
*     infragistics.util.js
*     infragistics.ext_core.js
*     infragistics.ext_collections.js
*     infragistics.dv_core.js
*     infragistics.dv_geometry.JS
*     infragistics.datachart_categorycore.js
*     infragistics.datachart_core.js
*     infragistics.ext_ui.js
*/
(function(factory){if(typeof define==="function"&&define.amd){define(["jquery","jquery-ui","./infragistics.util","./infragistics.ext_core","./infragistics.ext_collections","./infragistics.dv_core","./infragistics.dv_geometry","./infragistics.datachart_categorycore","./infragistics.datachart_core","./infragistics.ext_ui"],factory)}else{factory(jQuery)}})(function($){$.ig=$.ig||{};var $$t={};$.ig.globalDefs=$.ig.globalDefs||{};$.ig.globalDefs.$$h=$$t;$$0=$.ig.globalDefs.$$0;$$4=$.ig.globalDefs.$$4;$$1=$.ig.globalDefs.$$1;$$w=$.ig.globalDefs.$$w;$$r=$.ig.globalDefs.$$r;$$g=$.ig.globalDefs.$$g;$$j=$.ig.globalDefs.$$j;$$6=$.ig.globalDefs.$$6;$$a=$.ig.globalDefs.$$a;$.ig.$currDefinitions=$$t;$.ig.util.bulkDefine(["RangeCategoryBucketCalculator:a","RangeAreaSeries:b","RangeCategorySeries:g","RangeColumnSeries:h","RangeAreaSeriesView:i","RangeCategorySeriesView:j","RangeColumnSeriesView:k"]);var $a=$.ig.intDivide,$b=$.ig.util.cast,$c=$.ig.util.defType,$d=$.ig.util.getBoxIfEnum,$e=$.ig.util.getDefaultValue,$f=$.ig.util.getEnumValue,$g=$.ig.util.getValue,$h=$.ig.util.intSToU,$i=$.ig.util.nullableEquals,$j=$.ig.util.nullableIsNull,$k=$.ig.util.nullableNotEquals,$l=$.ig.util.toNullable,$m=$.ig.util.toString$1,$n=$.ig.util.u32BitwiseAnd,$o=$.ig.util.u32BitwiseOr,$p=$.ig.util.u32BitwiseXor,$q=$.ig.util.u32LS,$r=$.ig.util.unwrapNullable,$s=$.ig.util.wrapNullable,$t=String.fromCharCode,$u=$.ig.util.castObjTo$t,$v=$.ig.util.compareSimple,$w=$.ig.util.tryParseNumber,$x=$.ig.util.tryParseNumber1,$y=$.ig.util.numberToString,$z=$.ig.util.numberToString1,$0=$.ig.util.parseNumber,$1=$.ig.util.compare,$2=$.ig.util.replace,$3=$.ig.util.stringFormat,$4=$.ig.util.stringFormat1,$5=$.ig.util.stringFormat2,$6=$.ig.util.stringCompare1,$7=$.ig.util.stringCompare2,$8=$.ig.util.stringCompare3;$c("RangeCategoryBucketCalculator:a","CategoryBucketCalculator",{_j:null,init:function(a){this.i=null;this.h=null;$.ig.CategoryBucketCalculator.prototype.init.call(this,a);this._j=a},getBucketWithoutUnknowns:function(a){var b=false;var c=this.i;var d=this.h;var e=this.l;var f=this.k;var g=Math.min(e,f);var h=a*this.d;var i=Math.min(h+this.d-1,g-1);var j=1.7976931348623157e308;var k=-1.7976931348623157e308;var l=true;var m=0;var n=0;var o;var p;for(var q=h;q<=i;++q){m=c[q];n=d[q];if(m<n){o=m;p=n}else{p=m;o=n}if(!l){j=j<o?j:o;k=k>o?k:o;j=j<p?j:p;k=k>p?k:p}else{j=Math.min(j,o);k=Math.max(k,o);k=Math.max(k,p);j=Math.min(j,p);l=false}}if(b&&n<m){var r=j;j=k;k=r}if(!l){var s=new Array(3);s[0]=.5*(h+i);s[1]=j;s[2]=k;return s}var t=new Array(3);t[0]=NaN;t[1]=NaN;t[2]=NaN;return t},getBucket:function(a){var b=false;var c=this.i;var d=this.h;var e=this.l;var f=this.k;var g=Math.min(e,f);var h=a*this.d;var i=Math.min(h+this.d-1,g-1);var j=NaN;var k=NaN;var l=true;var m=0;var n=0;var o;var p;for(var q=h;q<=i;++q){m=c[q];n=d[q];if(m<n){o=m;p=n}else{p=m;o=n}if(!l){if(!$.ig.util.isNaN(o)){j=j<o?j:o;k=k>o?k:o}if(!$.ig.util.isNaN(p)){j=j<p?j:p;k=k>p?k:p}}else{if(!$.ig.util.isNaN(o)){if($.ig.util.isNaN(j)){j=o}else{j=Math.min(j,o)}if(!$.ig.util.isNaN(k)){k=Math.max(k,o)}}if(!$.ig.util.isNaN(p)){if($.ig.util.isNaN(k)){k=p}else{k=Math.max(k,p)}if(!$.ig.util.isNaN(j)){j=Math.min(j,p)}}if(!$.ig.util.isNaN(j)&&!$.ig.util.isNaN(k)){l=false}}}if(n<m&&b){var r=j;j=k;k=r}if(!l){var s=new Array(3);s[0]=.5*(h+i);s[1]=j;s[2]=k;return s}var t=new Array(3);t[0]=NaN;t[1]=NaN;t[2]=NaN;return t},l:0,k:0,i:null,h:null,cacheValues:function(){this.l=this._j._db.lowColumn().count();this.k=this._j._db.highColumn().count();this.i=this._j._db.lowColumn().asArray();this.h=this._j._db.highColumn().asArray()},unCacheValues:function(){this.i=null;this.h=null},$type:new $.ig.Type("RangeCategoryBucketCalculator",$.ig.CategoryBucketCalculator.prototype.$type)},true);$c("RangeCategorySeries:g","CategorySeries",{a7:function(){return new $$t.j(this)},h4:function(a){$.ig.CategorySeries.prototype.h4.call(this,a);this._n5=a},_n5:null,init:function(){$.ig.CategorySeries.prototype.init.call(this);this._n4=new $$t.c(1,this,this._n5,this,this,this._n5._c2)},_n4:null,lowMemberPath:function(a){if(arguments.length===1){this.g($$t.$g.lowMemberPathProperty,a);return a}else{return this.c($$t.$g.lowMemberPathProperty)}},lowColumn:function(a){if(arguments.length===1){if(this.n8!=a){var b=this.n8;this.n8=a;this.raisePropertyChanged("LowColumn",b,this.n8)}return a}else{return this.n8}},n8:null,highMemberPath:function(a){if(arguments.length===1){this.g($$t.$g.highMemberPathProperty,a);return a}else{return this.c($$t.$g.highMemberPathProperty)}},highColumn:function(a){if(arguments.length===1){if(this.n6!=a){var b=this.n6;this.n6=a;this.raisePropertyChanged("HighColumn",b,this.n6)}return a}else{return this.n6}},n6:null,mn:function(){return 11},nu:function(a,b){$.ig.CategorySeries.prototype.nu.call(this,a,b);b._cf=true;$.ig.CategoryMarkerManager.prototype.b(this,a.o,b._c5,this.useLightweightMarkers());this.no(b,a)},og:function(a,b,c,d,e,f){this._n5.dc(a,b,c,d,e,f)},scrollIntoView:function(a){var b=new $$a.aa(0,0,0,1,1);var c=this.view()!=null?this.view().b7():$$a.$aa.empty();var d=this.view()!=null?this.view().b6():$$a.$aa.empty();var e=!c.isEmpty()&&!d.isEmpty()&&this.bo()!=null?this.bo().indexOf(a):-1;var f=this.mb();var g=this.mc();var h=this.kz(this.view());var i;if(f!=null){var j=new $.ig.ScalerParams(0,b,b,f.isInverted(),h);i=f.getScaledValue(e,j)}else{i=NaN}var k=f!=null?this._n4.r($b($.ig.ICategoryScaler.prototype.$type,f),b,b,h):0;i+=k;if(e>=0&&$$a.$aa.l_op_Inequality(c,null)&&$$a.$aa.l_op_Inequality(d,null)){if(!$.ig.util.isNaN(i)){if(i<c.left()+.1*c.width()){i=i+.4*c.width()}if(i>c.right()-.1*c.width()){i=i-.4*c.width()}c.x(i-.5*c.width())}if(g!=null&&this.highColumn()!=null&&e<this.highColumn().count()){var l=new $.ig.ScalerParams(0,b,b,g.isInverted(),h);var m=g.getScaledValue(this.highColumn().item(e),l);var n=g.getScaledValue(this.lowColumn().item(e),l);if(!$.ig.util.isNaN(m)&&!$.ig.util.isNaN(n)){var o=Math.abs(n-m);if(c.height()<o){c.height(o);c.y(Math.min(n,m))}else{if(n<c.top()+.1*c.height()){n=n+.4*c.height()}if(n>c.bottom()-.1*c.height()){n=n-.4*c.height()}c.y(n-.5*c.height())}}}if(this.syncLink()!=null){this.syncLink().al(this.seriesViewer(),c)}}return e>=0},h9:function(a,b,c,d){$.ig.CategorySeries.prototype.h9.call(this,a,b,c,d);switch(b){case"FastItemsSource":if($b($.ig.IFastItemsSource.prototype.$type,c)!=null){c.deregisterColumn(this.lowColumn());c.deregisterColumn(this.highColumn());this.lowColumn(null);this.highColumn(null)}if($b($.ig.IFastItemsSource.prototype.$type,d)!=null){this.lowColumn(this.bl(this.lowMemberPath()));this.highColumn(this.bl(this.highMemberPath()))}if(!this.m6()){this._mm._c2.g(this.resolution());this.renderSeries(false)}break;case"LowMemberPath":if(this.bo()!=null){this.bo().deregisterColumn(this.lowColumn());this.lowColumn(this.bl(this.lowMemberPath()))}break;case"LowColumn":if(!this.m6()){this._mm._c2.g(this.resolution());this.renderSeries(false)}break;case"HighMemberPath":if(this.bo()!=null){this.bo().deregisterColumn(this.highColumn());this.highColumn(this.bl(this.highMemberPath()))}break;case"HighColumn":if(!this.m6()){this._mm._c2.g(this.resolution());this.renderSeries(false)}break}},aj:function(a){if(this.lowColumn()==null||this.lowColumn().count()==0||this.highColumn()==null||this.highColumn().count()==0){return null}if(a==this.mb()){var b=Math.min(this.lowColumn().count(),this.highColumn().count());return new $.ig.AxisRange(0,b-1)}if(a==this.mc()){var c=Math.min(this.lowColumn().minimum(),this.highColumn().minimum());var d=Math.max(this.lowColumn().maximum(),this.highColumn().maximum());return new $.ig.AxisRange(Math.min(c,d),Math.max(c,d))}return null},g4:function(a,b,c,d){if(this.mb()!=null&&$b($.ig.ISortingAxis.prototype.$type,this.mb())!==null){this.mb().notifyDataChanged()}var e=this.mb();switch(a){case 3:if(d==this.lowMemberPath()||d==this.highMemberPath()){if(e!=null){e.updateRange()}if(!this.m6()){this.renderSeries(true)}}break;case 1:if(e!=null){e.updateRange()}this._mm._c2.g(this.resolution());if(!this.m6()){this.renderSeries(true)}break;case 0:if(e!=null){e.updateRange()}this._mm._c2.g(this.resolution());if(!this.m6()){this.renderSeries(true)}break;case 2:if(e!=null){e.updateRange()}if(this.lowMemberPath()!=null&&this.highMemberPath()!=null&&this._mm._c2.d>0&&!this.m6()){this.renderSeries(true)}break;case 4:if(e!=null){e.updateRange()}this._mm._c2.g(this.resolution());if(!this.m6()){this.renderSeries(true)}break}},dc:function(a,b,c){var d=$.ig.CategorySeries.prototype.dc.call(this,a,b,c);if(this.lowColumn()==null||this.lowColumn().count()==0||this.highColumn()==null||this.highColumn().count()==0){d=false}return d},nr:function(a,b){$.ig.CategorySeries.prototype.nr.call(this,a,b);this._n4.d(a,b)},currentCategoryMode:function(){return this.preferredCategoryMode($b($.ig.CategoryAxisBase.prototype.$type,this.mb()))},scaler:function(){return $b($.ig.ICategoryScaler.prototype.$type,this.mb())},yScaler:function(){return $b($.ig.IScaler.prototype.$type,this.mc())},bucketizer:function(){return this._mm._c2},currentMode2Index:function(){return this.nf()},provideCollisionDetector:function(){return new $.ig.CollisionAvoider},mayContainUnknowns:function(){return this.lowColumn()==null||this.lowColumn().mayContainUnknowns()||this.highColumn()==null||this.highColumn().mayContainUnknowns()},iq:function(a,b){var c=this.c3();$.ig.CategorySeries.prototype.iq.call(this,a,b);if(!c){this.view().a6(b);return}this.view().a6(b);if(this.b0(this._a8)){return}var d=new $$t.c(1,this,$b($.ig.ISupportsMarkers.prototype.$type,this._a8),this.seriesViewer()._bh._p,this,this._a8._c2);if(!this._cx){this.mg=new $.ig.CategoryFrame(3);this.mg.w();d.d(this.mg,this._a8)}this._cx=false;this.nu(this.mg,this._a8);this.c3(false)},_n3:null,renderAlternateView:function(a,b,c,d,e){$.ig.CategorySeries.prototype.renderAlternateView.call(this,a,b,c,d,e);var f=this.de().item(d);var g=f;g._c2.g(this.resolution());f.a5(c);if(this.b0(g)){return}var h=new $$t.c(1,this,$b($.ig.ISupportsMarkers.prototype.$type,f),f,this,f._c2);if(this._n3==null){this._n3=new $.ig.CategoryFrame(3)}this._n3.w();h.d(this._n3,g);this.nu(this._n3,g)},$type:new $.ig.Type("RangeCategorySeries",$.ig.CategorySeries.prototype.$type,[$.ig.IIsCategoryBased.prototype.$type,$.ig.IHasHighLowValueCategory.prototype.$type])},true);$c("HorizontalRangeCategorySeries:f","RangeCategorySeries",{init:function(){$$t.$g.init.call(this)},xAxis:function(a){if(arguments.length===1){this.g($$t.$f.xAxisProperty,a);return a}else{return this.c($$t.$f.xAxisProperty)}},yAxis:function(a){if(arguments.length===1){this.g($$t.$f.yAxisProperty,a);return a}else{return this.c($$t.$f.yAxisProperty)}},mb:function(){return this.xAxis()},mc:function(){return this.yAxis()},ad:function(a){var b=this.af(this.md(),this.me.h,this.nc(this.view()),this.nd(this.view()),this.toWorldPosition(a),true);if(b==null){return null}var c=b[0];var d=b[1];var e=new Array(1);var f=new Array(2);f[0]={__x:c[0],__y:c[2],$type:$.ig.Point.prototype.$type,getType:$.ig.Object.prototype.getType,getGetHashCode:$.ig.Object.prototype.getGetHashCode,typeName:$.ig.Object.prototype.typeName};f[1]={__x:d[0],__y:d[2],$type:$.ig.Point.prototype.$type,getType:$.ig.Object.prototype.getType,getGetHashCode:$.ig.Object.prototype.getGetHashCode,typeName:$.ig.Object.prototype.typeName};e[0]=f;return e},ae:function(a){var b=this.af(this.md(),this.me.h,this.nc(this.view()),this.nd(this.view()),this.toWorldPosition(a),true);if(b==null){return null}var c=b[0];var d=b[1];var e=new Array(1);var f=new Array(2);f[0]={__x:c[0],__y:c[1],$type:$.ig.Point.prototype.$type,getType:$.ig.Object.prototype.getType,getGetHashCode:$.ig.Object.prototype.getGetHashCode,typeName:$.ig.Object.prototype.typeName};f[1]={__x:d[0],__y:d[1],$type:$.ig.Point.prototype.$type,getType:$.ig.Object.prototype.getType,getGetHashCode:$.ig.Object.prototype.getGetHashCode,typeName:$.ig.Object.prototype.typeName};e[0]=f;return e},isRange:function(){return true},a5:function(){if(this.hitTestMode()==0){return 1}else{return $$t.$g.a5.call(this)}},getOffsetValue:function(){return this._n4.r(this.xAxis(),this.view().b7(),this.view().b6(),this.getEffectiveViewport1(this.view()))},getCategoryWidth:function(){return this.xAxis().getCategorySize(this.view().b7(),this.view().b6(),this.getEffectiveViewport1(this.view()))},getNextOrExactIndex:function(a,b){return this.et(a,b,this.xAxis(),this.na.runOn(this),new $.ig.RangeValueList(this.highColumn(),this.lowColumn()))},getPreviousOrExactIndex:function(a,b){return this.ev(a,b,this.xAxis(),this.na.runOn(this),new $.ig.RangeValueList(this.highColumn(),this.lowColumn()))},du:function(a,b,c,d,e){if(c==null){return Number.POSITIVE_INFINITY}var f=this.xAxis().ig;return this.dv(a,b,this.xAxis(),d,e,f,this.na.runOn(this))},getSeriesValue:function(a,b,c){if(this.seriesViewer()==null){return NaN}var d=this.getEffectiveViewport1(this.view());var e=new $.ig.ScalerParams(0,this.seriesViewer().actualWindowRect(),this.view().b6(),this.xAxis().isInverted(),d);var f=this._n4.r(this.xAxis(),this.seriesViewer().actualWindowRect(),this.view().b6(),d);return this.d8(new $.ig.RangeValueList(this.highColumn(),this.lowColumn()),a,this.xAxis(),e,f,this.na.runOn(this),b,c)},getSeriesLowValue:function(a,b,c){if(this.seriesViewer()==null){return NaN}var d=this.getEffectiveViewport1(this.view());var e=new $.ig.ScalerParams(0,this.seriesViewer().actualWindowRect(),this.view().b6(),this.xAxis().isInverted(),d);var f=this._n4.r(this.xAxis(),this.seriesViewer().actualWindowRect(),this.view().b6(),d);return this.d8(this.lowColumn(),a,this.xAxis(),e,f,this.na.runOn(this),b,c)},getSeriesHighValue:function(a,b,c){if(this.seriesViewer()==null){return NaN}var d=this.getEffectiveViewport1(this.view());var e=new $.ig.ScalerParams(0,this.seriesViewer().actualWindowRect(),this.view().b6(),this.xAxis().isInverted(),d);var f=this._n4.r(this.xAxis(),this.seriesViewer().actualWindowRect(),this.view().b6(),d);return this.d8(this.highColumn(),a,this.xAxis(),e,f,this.na.runOn(this),b,c)},getSeriesHighValuePosition:function(a,b,c){var $self=this;return this.ku(a,b,c,this._n4.r(this.xAxis(),this.view().b7(),this.view().b6(),this.getEffectiveViewport1(this.view())),this.yAxis(),this.xAxis(),this.getSeriesHighValue.runOn(this),function(d,e){return $self.ev(d,e,$self.xAxis(),$self.na.runOn($self),$self.highColumn())},function(d,e){return $self.et(d,e,$self.xAxis(),$self.na.runOn($self),$self.highColumn())})},getSeriesLowValuePosition:function(a,b,c){var $self=this;return this.ku(a,b,c,this._n4.r(this.xAxis(),this.view().b7(),this.view().b6(),this.getEffectiveViewport1(this.view())),this.yAxis(),this.xAxis(),this.getSeriesLowValue.runOn(this),function(d,e){return $self.ev(d,e,$self.xAxis(),$self.na.runOn($self),$self.lowColumn())},function(d,e){return $self.et(d,e,$self.xAxis(),$self.na.runOn($self),$self.lowColumn())})},getSeriesValuePosition:function(a,b,c){return this.ku(a,b,c,this._n4.r(this.xAxis(),this.view().b7(),this.view().b6(),this.getEffectiveViewport1(this.view())),this.yAxis(),this.xAxis(),null,null,null)},m6:function(){return this.yAxis()!=null&&this.yAxis().updateRange()},h9:function(a,b,c,d){$$t.$g.h9.call(this,a,b,c,d);switch(b){case"XAxis":this.g5($b($.ig.Axis.prototype.$type,c));this.id($b($.ig.Axis.prototype.$type,d));this._mm._c2.g(this.resolution());this.renderSeries(false);this.hp();break;case"YAxis":this.g5($b($.ig.Axis.prototype.$type,c));this.id($b($.ig.Axis.prototype.$type,d));this._mm._c2.g(this.resolution());this.m6();this.renderSeries(false);this.hp();break}},canUseAsYAxis:function(a){if($b($.ig.NumericYAxis.prototype.$type,a)!==null){return true}return false},canUseAsXAxis:function(a){if($b($.ig.CategoryXAxis.prototype.$type,a)!==null||a.isDateTime()){return true}return false},$type:new $.ig.Type("HorizontalRangeCategorySeries",$$t.$g.$type)},true);$c("RangeAreaSeries:b","HorizontalRangeCategorySeries",{a7:function(){return new $$t.i(this)},h4:function(a){$$t.$f.h4.call(this,a);this._or=a},_or:null,isAreaOrLine:function(){return true},os:function(a,b,c,d){if($.ig.util.isNaN(b.__x)||$.ig.util.isNaN(b.__y)){return false}if($.ig.util.isNaN(c.__x)||$.ig.util.isNaN(c.__y)){return false}if(a.__y<=b.__y&&a.__y>=c.__y){return true}return false},testHit:function(a,b){if(this.cy(a,b)){return true}if(this.lb(a,b)){return true}return false},init:function(){$$t.$f.init.call(this);this._y=$$t.$b.$type},preferredCategoryMode:function(a){return 0},g2:function(a,b){$$t.$f.g2.call(this,a,b);var c=b;c.de()},nu:function(a,b){$$t.$f.nu.call(this,a,b);var c=a.h.count();var d=new $$4.v(Array,2,c);for(var e=0;e<c;e++){var f=a.h.__inner[e];var g=new Array(4);g[0]=f[0];g[1]=f[1];var h=a.h.__inner[a.h.count()-1-e];g[2]=h[0];g[3]=h[2];d.add(g)}var i=$b($$t.$i.$type,b);var j=this.getEffectiveViewport1(i);this.ml.x(this,this.m4(),this.xAxis(),this.getCategoryItems.runOn(this),this.nc(b),this.nd(b));var k=false;var l=this.ml._c;if(l!=null){k=true}if(k){var m=new $.ig.ScalerParams(0,b.b7(),b.b6(),this.xAxis().isInverted(),j);this.nq(d,-1,this.lowColumn().count(),this.xAxis(),m,b.p())}var n=i.dm();var o=i.dp();var p=i.di();this.ml.ae(n,true,false,true,true);this.ml.ae(o,true,false,true,true);this.ml.ae(p,false,true,false,false);if(b.c6(a)){i.df(a.h.count(),d,false);b.c9(a)}i.di().__opacity=this.ml.i*this.actualAreaFillOpacity()},$type:new $.ig.Type("RangeAreaSeries",$$t.$f.$type)},true);$c("RangeCategoryFramePreparer:c","CategoryFramePreparerBase",{init:function(a,b){if(a>0){switch(a){case 1:this.init1.apply(this,arguments);break}return}$$t.$c.init1.call(this,1,b,$b($.ig.ISupportsMarkers.prototype.$type,b),$b($.ig.IProvidesViewport.prototype.$type,b),$b($.ig.ISupportsErrorBars.prototype.$type,b),$b($.ig.IBucketizer.prototype.$type,b))},init1:function(a,b,c,d,e,f){$.ig.CategoryFramePreparerBase.prototype.init1.call(this,1,b,c,d,e,f);this._ab=new $.ig.DefaultCategoryTrendlineHost;if($b($.ig.IHasCategoryTrendline.prototype.$type,b)!==null){this._ab=$b($.ig.IHasCategoryTrendline.prototype.$type,b)}this._ac=new $$t.e;if($b($.ig.IHasHighLowValueCategory.prototype.$type,b)!==null){this._ac=$b($.ig.IHasHighLowValueCategory.prototype.$type,b)}},_ab:null,_ac:null,l:function(a,b,c,d,e,f){var g=b[0];var h=b[1];var i=b[2];if(!$.ig.util.isNaN(g)&&!$.ig.util.isNaN(h)&&!$.ig.util.isNaN(i)){a.o.add({__x:g,__y:(h+i)/2,$type:$.ig.Point.prototype.$type,getType:$.ig.Object.prototype.getType,getGetHashCode:$.ig.Object.prototype.getGetHashCode,typeName:$.ig.Object.prototype.typeName});this._c.updateMarkerTemplate(e,d,f);return true}return false},aa:function(a,b,c,d){var e=a;var f=e._f;var g=e._g;var h=this.u(f.item(b));var i=this.u(g.item(b));var j=Math.max(h,i);var k=Math.min(h,i);if(c){e._d=k;e._e=j}else{e._c=j;e._b=k}},v:function(a,b,c){var d=a;var e=d._f;var f=d._g;var g=this.u(e.item(b));var h=this.u(f.item(b));if(!isNaN(g)){d._c=Math.max(d._c,g);d._b=Math.min(d._b,g)}if(!isNaN(h)){d._c=Math.max(d._c,h);d._b=Math.min(d._b,h)}},e:function(a,b){var c=b;return[this.u(a),c._b,c._c]},y:function(a,b,c,d,e,f){if(d){b[0]=b[0]+c}else{b[0]=a._b.getScaledValue(b[0],e)+c}b[1]=a._c.getScaledValue(b[1],f);b[2]=a._c.getScaledValue(b[2],f)},z:function(a,b,c,d,e,f,g){$.ig.CategoryFramePreparerBase.prototype.z.call(this,a,b,c,d,e,f,g);var h=a._h;var i=a._a.h.count();var j=a._a.h;var k=this.q();var l=k.count();var m=b;var n=new $$4.v($.ig.Number.prototype.$type,0);if(!c){n.add(0)}var o=new $$4.v($.ig.Number.prototype.$type,0);o.add(1);o.add(2);a._b.getScaledBucketValueList(j,n,0,i,d);a._c.getScaledBucketValueList(j,o,0,i,e);for(var p=0;p<i;p++){j.__inner[p][0]=j.__inner[p][0]+m}if(g){a._b.getScaledBucketValueList(k,n,0,l,d);a._c.getScaledBucketValueList(k,o,0,l,e);for(var q=0;q<l;q++){k.__inner[q][0]=k.__inner[q][0]+m}}},j:function(a){var b=new $$t.d;b._f=this._ac.highColumn();b._g=this._ac.lowColumn();return b},$type:new $.ig.Type("RangeCategoryFramePreparer",$.ig.CategoryFramePreparerBase.prototype.$type)},true);$c("HighLowValuesHolder:d","ValuesHolder",{init:function(){$.ig.ValuesHolder.prototype.init.call(this)},_f:null,_g:null,a:function(){if(this._f==null||this._g==null){return 0}return Math.min(this._f.count(),this._g.count())},$type:new $.ig.Type("HighLowValuesHolder",$.ig.ValuesHolder.prototype.$type)},true);$c("DefaultHighLowValueProvider:e","Object",{init:function(){$.ig.$op.init.call(this)},highColumn:function(){return new $$4.v(Number,0)},lowColumn:function(){return new $$4.v(Number,0)},$type:new $.ig.Type("DefaultHighLowValueProvider",$.ig.$ot,[$.ig.IHasHighLowValueCategory.prototype.$type])},true);$c("RangeColumnSeries:h","HorizontalRangeCategorySeries",{a7:function(){return new $$t.k(this)},h4:function(a){$$t.$f.h4.call(this,a);this._or=a},_or:null,init:function(){$$t.$f.init.call(this);this._y=$$t.$h.$type},radiusX:function(a){if(arguments.length===1){this.g($$t.$h.radiusXProperty,a);return a}else{return this.c($$t.$h.radiusXProperty)}},radiusY:function(a){if(arguments.length===1){this.g($$t.$h.radiusYProperty,a);return a}else{return this.c($$t.$h.radiusYProperty)}},m0:function(){return true},preferredCategoryMode:function(a){return 2},getSeriesValueBoundingBox:function(a){var b=this.fromWorldPosition(a);var c=this.view().b7();var d=this.view().b6();var e=this.getEffectiveViewport1(this.view());var f=new $.ig.ScalerParams(0,c,d,this.yAxis().isInverted(),e);var g=this.af(this.md(),this.me.h,this.nc(this.view()),this.nd(this.view()),a,true);if(g==null){return $$a.$aa.empty()}var h=g[0];var i=g[1];var j=Math.abs(b.__x-h[0]);var k=Math.abs(b.__x-i[0]);var l=this.xAxis().ia(c,d,e);if(j<k){var m=h[0]-.5*l;var n=h[1];var o=h[2];return new $$a.aa(0,m,Math.min(n,o),l,Math.max(n,o)-Math.min(n,o))}else{var p=i[0]-.5*l;var q=i[1];var r=i[2];return new $$a.aa(0,p,Math.min(q,r),l,Math.max(q,r)-Math.min(q,r))}},testHit:function(a,b){if(this.c2(a,b)){return true}if(this.lb(a,b)){return true}return false},g2:function(a,b){$$t.$f.g2.call(this,a,b);var c=b;if(a&&c._de!=null){c._de.count(0)}},getItemSpan:function(){return this.xAxis().ia(this.view().b7(),this.view().b6(),this.getEffectiveViewport1(this.view()))},nu:function(a,b){$$t.$f.nu.call(this,a,b);var c=$b($$t.$k.$type,b);var d=a.h;var e=b.b7();var f=b.b6();var g=this.getEffectiveViewport1(b);var h=this.xAxis().ia(e,f,g);if($.ig.util.isNaN(h)||Number.isInfinity(h)){c._de.count(0);return}this.ml.x(this,this.m4(),this.xAxis(),this.getCategoryItems.runOn(this),this.nc(b),this.nd(b));this.ml.p=this.radiusX();this.ml.q=this.radiusY();this.ml.j=this.radiusX();this.ml.k=this.radiusY();var i=false;var j=this.ml._c;if(j!=null){i=true}var k=this.xAxis().isSorting();var l=this.lowColumn().count();var m=this.xAxis();var n=new $.ig.ScalerParams(0,e,f,this.xAxis().isInverted(),g);var o=0;for(var p=0;p<d.count();++p){var q=d.__inner[p][0]-.5*h;var r=Math.min(d.__inner[p][1],d.__inner[p][2]);var s=Math.max(d.__inner[p][1],d.__inner[p][2]);var t=Math.abs(s-r);if(Number.isInfinity(t)){continue}var u=c._de.item(o);o++;u.width(h);u.height(t);if(i){this.nq(d,p,l,m,n,b.p())}this.ml.ae(u,false,false,false,false);u.ai(this.ml.j);u.aj(this.ml.k);c.dj(u,q,r)}c._de.count(o);b.c9(a)},$type:new $.ig.Type("RangeColumnSeries",$$t.$f.$type)},true);$c("RangeCategorySeriesView:j","CategorySeriesView",{_db:null,init:function(a){$.ig.CategorySeriesView.prototype.init.call(this,a);this._db=a},dc:function(a,b,c,d,e,f){a._ag.clear();b._ag.clear();c._ag.clear();var g=$.ig.Flattener.prototype.b(d,e,true,f,this._e.resolution());var h=$.ig.Flattener.prototype.b(d,e,false,f,this._e.resolution());var i=g.count();var j=h.count();var k;var l;var m;var n;for(var o=0;o<i;o++){k=g.item(o);l=e.__inner[k];m=l[0];n=l[1];a._ag.add({__x:m,__y:n,$type:$.ig.Point.prototype.$type,getType:$.ig.Object.prototype.getType,getGetHashCode:$.ig.Object.prototype.getGetHashCode,typeName:$.ig.Object.prototype.typeName});b._ag.add({__x:m,__y:n,$type:$.ig.Point.prototype.$type,getType:$.ig.Object.prototype.getType,getGetHashCode:$.ig.Object.prototype.getGetHashCode,typeName:$.ig.Object.prototype.typeName})}var p;var q;for(var r=0;r<j;r++){k=h.item(r);l=e.__inner[k];if(f){p=l[0];q=l[2]}else{p=l[2];q=l[3]}c._ag.add({__x:p,__y:q,$type:$.ig.Point.prototype.$type,getType:$.ig.Object.prototype.getType,getGetHashCode:$.ig.Object.prototype.getGetHashCode,typeName:$.ig.Object.prototype.typeName});b._ag.add({__x:p,__y:q,$type:$.ig.Point.prototype.$type,getType:$.ig.Object.prototype.getType,getGetHashCode:$.ig.Object.prototype.getGetHashCode,typeName:$.ig.Object.prototype.typeName})}a._y=a._ag.count()>0;b._y=b._ag.count()>0;c._y=c._ag.count()>0},c3:function(){return new $$t.a(this)},getDefaultTooltipTemplate:function(){var a="<div class='ui-chart-default-tooltip-content'>";var b=null;if(this._db.mb().isCategory()){b=this._db.mb()}else if(this._db.mc().isCategory()){b=this._db.mc()}if(b.isDateTime()){var c=b;a+="<span>${item."+c.dateTimeMemberPath()+"}</span><br/>"}else if(b!=null&&b.label()!=null){a+="<span>${item."+b.label()+"}</span><br/>"}a+="<span";var d=this.ai();if(!String.isNullOrEmpty(d)){a+=" style='color:"+d+"'"}a+=">"+this._db.title()+": </span><span class='ui-priority-primary'>"+"${item."+this._db.lowMemberPath()+"} - ${item."+this._db.highMemberPath()+"}</span></div>";return a},$type:new $.ig.Type("RangeCategorySeriesView",$.ig.CategorySeriesView.prototype.$type)},true);$c("RangeAreaSeriesView:i","RangeCategorySeriesView",{_dd:null,init:function(a){this.dl=new $$a.bp;this.dh=new $$a.bo;this.dn=new $$a.bp;this.dk=new $$a.bp;this.dj=new $$a.bp;this.dg=new $$a.bo;$$t.$j.init.call(this,a);this._dd=a},aw:function(){$$t.$j.aw.call(this);if(!this.p()){this._e.legendItemBadgeTemplate(function(){var $ret=new $$a.h;$ret.render($.ig.LegendTemplates.prototype.m);$ret.measure($.ig.LegendTemplates.prototype.g);return $ret}())}},dl:null,dh:null,dn:null,dm:function(){return this.dl},di:function(){return this.dh},dp:function(){return this.dn},de:function(){this.dh._ag.clear();this.dl._ag.clear();this.dn._ag.clear()},df:function(a,b,c){this.dc(this.dl,this.dh,this.dn,a,b,c);this.au()},dk:null,dj:null,dg:null,bg:function(){$$t.$j.bg.call(this);this.dj._ag=this.dl._ag;this.dk._ag=this.dn._ag;this.dg._ag=this.dh._ag;var a=this.b0();this.dj.__stroke=a;this.dj._z=this._e.thickness()+3;this.dk.__stroke=a;this.dk._z=this._e.thickness()+3;this.dg.__fill=a;this.dg.__opacity=1},ba:function(a,b){$$t.$j.ba.call(this,a,b);if(a.d()){if(b){a.t(this.dg);a.u(this.dj);a.u(this.dk)}else{a.t(this.dh);a.u(this.dl);a.u(this.dn)}}},ap:function(a){$$t.$j.ap.call(this,a);var b=new $.ig.PolyLineVisualData(1,"lowerShape",this.dl);b.tags().add("Lower");var c=new $.ig.PolyLineVisualData(1,"upperShape",this.dn);c.tags().add("Upper");c.tags().add("Main");var d=new $.ig.PolygonVisualData(1,"fillShape",this.dh);d.tags().add("Fill");a.shapes().add(b);a.shapes().add(c);a.shapes().add(d)},$type:new $.ig.Type("RangeAreaSeriesView",$$t.$j.$type)},true);$c("RangeColumnSeriesView:k","RangeCategorySeriesView",{_dd:null,init:function(a){var $self=this;this.dk=new $$a.bq;$$t.$j.init.call(this,a);this._dd=a;this._de=function(){var $ret=new $.ig.Pool$1($$a.$bq.$type);$ret.create($self.dl.runOn($self));$ret.activate($self.dg.runOn($self));$ret.disactivate($self.di.runOn($self));$ret.destroy($self.dh.runOn($self));return $ret}()},_de:null,aw:function(){$$t.$j.aw.call(this);this._df=new $$4.v($$a.$bq.$type,0);if(!this.p()){this._e.resolution(4);this._e.legendItemBadgeTemplate(function(){var $ret=new $$a.h;$ret.render($.ig.LegendTemplates.prototype.m);$ret.measure($.ig.LegendTemplates.prototype.g);return $ret}())}},_df:null,dl:function(){var a=new $$a.bq;this._df.add(a);a.__visibility=1;return a},dg:function(a){a.__visibility=0},di:function(a){a.__visibility=1},dh:function(a){this._df.remove(a)},dj:function(a,b,c){if(!this.isDirty()){this.au()}a._m=c;a._l=b},ad:function(a){return this._df.__inner[a]},dk:null,ac:function(a){var b=this._df.__inner[a];this.dk.__visibility=b.__visibility;this.dk._l=b._l;this.dk._m=b._m;this.dk.width(b.width());this.dk.height(b.height());var c=this.b1(a);this.dk.__fill=c;this.dk.__stroke=c;this.dk._z=this._e.thickness()+3;return this.dk},ba:function(a,b){$$t.$j.ba.call(this,a,b);if(a.d()){for(var c=0;c<this._df.count();c++){var d=this.ab(c,b);this.bh(d,c,b);a.v(d)}}},ap:function(a){$$t.$j.ap.call(this,a);var b=0;var c=new $$4.v($$a.$bq.$type,0);var e=this._de._a.getEnumerator();while(e.moveNext()){var d=e.current();c.add(d)}c.sort2(function(f,g){if(f._l<g._l){return-1}else if(f._l>g._l){return 1}else{return 0}});var g=c.getEnumerator();while(g.moveNext()){var f=g.current();var h=new $.ig.RectangleVisualData(1,"column"+b,f);h.tags().add("Main");h.tags().add("Fill");a.shapes().add(h)}b++},$type:new $.ig.Type("RangeColumnSeriesView",$$t.$j.$type)},true);$$t.$g.of="LowMemberPath";$$t.$g.od="LowColumn";$$t.$g.oc="HighMemberPath";$$t.$g.oa="HighColumn";$$t.$g.lowMemberPathProperty=$$a.$p.i("LowMemberPath",String,$$t.$g.$type,new $$a.y(2,null,function(a,b){a.raisePropertyChanged("LowMemberPath",b.d(),b.c())}));$$t.$g.highMemberPathProperty=$$a.$p.i("HighMemberPath",String,$$t.$g.$type,new $$a.y(2,null,function(a,b){a.raisePropertyChanged("HighMemberPath",b.d(),b.c())}));$$t.$f.on="XAxis";$$t.$f.oo="YAxis";$$t.$f.xAxisProperty=$$a.$p.i("XAxis",$.ig.CategoryAxisBase.prototype.$type,$$t.$f.$type,new $$a.y(2,null,function(a,b){a.raisePropertyChanged("XAxis",b.d(),b.c())}));$$t.$f.yAxisProperty=$$a.$p.i("YAxis",$.ig.NumericYAxis.prototype.$type,$$t.$f.$type,new $$a.y(2,null,function(a,b){a.raisePropertyChanged("YAxis",b.d(),b.c())}));$$t.$h.ou="RadiusX";$$t.$h.ov="RadiusY";$$t.$h.radiusXProperty=$$a.$p.i("RadiusX",Number,$$t.$h.$type,new $$a.y(2,2,function(a,b){a.raisePropertyChanged("RadiusX",b.d(),b.c())}));$$t.$h.radiusYProperty=$$a.$p.i("RadiusY",Number,$$t.$h.$type,new $$a.y(2,2,function(a,b){a.raisePropertyChanged("RadiusY",b.d(),b.c())}))});