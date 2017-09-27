﻿/*!@license
* Infragistics.Web.ClientUI Barcode 16.2.20162.2040
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
* Depends on:
*     jquery-1.8.3.js
*     jquery.ui.core.js
*     jquery.ui.widget.js
*     infragistics.util.js
*     infragistics.dv.simple.core.js
*     infragistics.barcode_qrcodebarcode.js
*/
(function(factory){if(typeof define==="function"&&define.amd){define(["jquery","jquery-ui","./infragistics.util","./infragistics.dv.simple.core","./infragistics.barcode_qrcodebarcode"],factory)}else{factory(jQuery)}})(function($){/*!@license
* Infragistics.Web.ClientUI Barcode localization resources 16.2.20162.2040
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/
$.ig=$.ig||{};if(!$.ig.Barcode){$.ig.Barcode={locale:{aILength:"AI は 2 つのディジット以上にする必要があります。",badFormedUCCValue:"UCC バーコードの Data プロパティが有効な値に設定されていません。(AI)GTIN の書式に設定してください。",code39_NonNumericError:"文字 '{0}' は CODE39 の Data プロパティで無効です。有効な文字は {1} です。",countryError:"国コードの変換に失敗しました。数値にする必要があります。",emptyValueMsg:"Data 値は空です。",encodingError:"変換でエラーが発生しました。有効なプロパティ値についてはヘルプを参照してください。",errorMessageText:"無効な値です。ヘルプを参照して、バーコードの有効な Data 値を確認してください。",gS1ExMaxAlphanumNumber:"GS1 DataBar Expanded のバーコードは 41 英数字以下の文字をエンコードできます。",gS1ExMaxNumericNumber:"GS1 DataBar Expanded のバーコードは 74 数字以下の文字をエンコードできます。",gS1Length:"GS1 DataBar の Data プロパティは GTIN のために使用されます。長さは 7、11、12、または 13 に設定する必要があります。最後の数字はチェックサムです。",gS1LimitedFirstChar:"GS1 DataBar Limited のバーコードの最初の数字は 0 または 1 に設定する必要があります。1 より大きい Indicator 値を持つ GTIN-14 データをエンコードするときに、バーコードのタイプは Omnidirectional、Stacked、Stacked Omnidirectional、または Truncated に設定する必要があります。",i25Length:"Interleaved2of5 バーコードは偶数の数字を持つ必要があります。奇数の場合、0 を数字の最初に追加します。",intelligentMailLength:"Intelligent Mail バーコードの Data プロパティの長さは 20、25、29、または 31 桁に設定する必要があります。トラック コードは 20 桁 (バーコードの ID は 2 数字、サービス タイプの ID は 3 数字、メーラーの ID は 6 または 9 数字、シリアル数は 9 または 6 数字) に設定して、郵便番号は 0、5、9、または 11 桁に設定します。",intelligentMailSecondDigit:"2 番目の数字は 0～4 の範囲に設定する必要があります。",invalidAI:"アプリケーション識別子要素の文字列は無効です。データの AI 文字列を有効な文字列に設定してください。",invalidCharacter:"'{0}' の文字が現在のバーコードのタイプで無効です。有効な文字は {1} です。",invalidDimension:"Stretch、BarsFillMode と XDimension のプロパティ値の組み合わせが無効なため、バーコードの寸法は確定できません。",invalidHeight:"バーコード グリッドの {0} 行は {1} ピクセルの高さに設定できません。",invalidLength:"バーコードの Data プロパティは、{0} 桁である必要があります。",invalidPostalCode:"無効な PostalCode 値 - モード 2 は、5 桁または 9 桁の米国の郵便番号をエンコードします。モード 3 は 6 文字 (英数字) コード以下をエンコードします。",invalidPropertyValue:"{0} プロパティ値は {1} ～ {2} の範囲内に設定する必要があります。",invalidVersion:"現在のエンコード モードおよびエラーの修正レベルでは、SizeVersion 数はデータをエンコードするために十分なセルを生成しません。",invalidWidth:"バーコード グリッドの {0} 列は {1} ピクセルの幅に設定できません。XDimension と WidthToHeightRatio の両方、またはそのいずれかのプロパティ値をチェックしてください。",invalidXDimensionValue:"現在のバーコード タイプは XDimension 値が {0} から {1} の範囲内である必要があります。",maxLength:"{0} は現在のバーコード タイプでエンコードできる最大長を超えています。エンコード可能な最大長は {1} 文字です。",notSupportedEncoding:"{0} {1} に対するエンコード化はサポートされていません。",pDF417InvalidRowsColumnsCombination:"(Data およびエラー修正の) コードワードの長さが行列 {0} x {1} の記号でエンコード可能な最大値を超えています。",primaryMessageError:"最初のメッセージ データを Data 値から取得できません。構造についてはヘルプを参照してください。",serviceClassError:"サービス クラスの変換に失敗しました。数値にする必要があります。",smallSize:"定義された Stretch 設定の場合、グリッドを Size({0}, {1}) に合わせません。",unencodableCharacter:"'{0}' の文字はエンコードできません。",uPCEFirstDigit:"UPCE の最初の数字は 0 に設定する必要があります。",warningString:"Barcode 警告: ",wrongCompactionMode:"Data メッセージを {0} モードで圧縮することはできません。",notLoadedEncoding:"{0} エンコードは読み込まれません。"}}}$.widget("ui.igQRCodeBarcode",{css:{unsupportedBrowserClass:"ui-html5-non-html5-supported-message ui-helper-clearfix ui-html5-non-html5",barcode:"ui-barcode",barcodeBacking:"ui-barcode-backing",barcodeBar:"ui-barcode-bar",barcodeLabel:"ui-barcode-label"},events:{errorMessageDisplaying:null,dataChanged:null},options:{width:null,height:null,backingBrush:"white",backingOutline:"transparent",backingStrokeThickness:0,barBrush:"black",fontBrush:null,font:null,data:"",errorMessageText:"",stretch:"uniform",barsFillMode:"fillSpace",widthToHeightRatio:3,xDimension:.25,errorCorrectionLevel:"medium",sizeVersion:"undefined",encodingMode:"undefined",eciNumber:3,eciHeaderDisplayMode:"hide",fnc1Mode:"none",applicationIndicator:""},_setOption:function(key,value,checkPrev){var qRCodeBarcode=this._qRCodeBarcode,o=this.options;if(checkPrev&&o[key]===value){return}$.Widget.prototype._setOption.apply(this,arguments);if(this._set_option(qRCodeBarcode,key,value)){return this}this._set_generated_option(qRCodeBarcode,key,value);return this},_set_generated_option:function(qRCodeBarcode,key,value){switch(key){case"backingBrush":if(value==null){qRCodeBarcode.backingBrush(null)}else{var $tempBrush=$.ig.Brush.prototype.create(value);qRCodeBarcode.backingBrush($tempBrush)}return true;case"backingOutline":if(value==null){qRCodeBarcode.backingOutline(null)}else{var $tempBrush=$.ig.Brush.prototype.create(value);qRCodeBarcode.backingOutline($tempBrush)}return true;case"backingStrokeThickness":qRCodeBarcode.backingStrokeThickness(value);return true;case"barBrush":if(value==null){qRCodeBarcode.barBrush(null)}else{var $tempBrush=$.ig.Brush.prototype.create(value);qRCodeBarcode.barBrush($tempBrush)}return true;case"fontBrush":if(value==null){qRCodeBarcode.fontBrush(null)}else{var $tempBrush=$.ig.Brush.prototype.create(value);qRCodeBarcode.fontBrush($tempBrush)}return true;case"font":qRCodeBarcode.font(value);return true;case"data":qRCodeBarcode.data(value);return true;case"errorMessageText":qRCodeBarcode.errorMessageText(value);return true;case"stretch":switch(value){case"none":qRCodeBarcode.stretch(0);break;case"fill":qRCodeBarcode.stretch(1);break;case"uniform":qRCodeBarcode.stretch(2);break;case"uniformToFill":qRCodeBarcode.stretch(3);break}return true;case"barsFillMode":switch(value){case"fillSpace":qRCodeBarcode.barsFillMode(0);break;case"ensureEqualSize":qRCodeBarcode.barsFillMode(1);break}return true;case"widthToHeightRatio":qRCodeBarcode.widthToHeightRatio(value);return true;case"xDimension":qRCodeBarcode.xDimension(value);return true;case"errorCorrectionLevel":switch(value){case"low":qRCodeBarcode.errorCorrectionLevel(1);break;case"medium":qRCodeBarcode.errorCorrectionLevel(0);break;case"quartil":qRCodeBarcode.errorCorrectionLevel(3);break;case"high":qRCodeBarcode.errorCorrectionLevel(2);break}return true;case"sizeVersion":switch(value){case"undefined":qRCodeBarcode.sizeVersion(0);break;case"version1":qRCodeBarcode.sizeVersion(1);break;case"version2":qRCodeBarcode.sizeVersion(2);break;case"version3":qRCodeBarcode.sizeVersion(3);break;case"version4":qRCodeBarcode.sizeVersion(4);break;case"version5":qRCodeBarcode.sizeVersion(5);break;case"version6":qRCodeBarcode.sizeVersion(6);break;case"version7":qRCodeBarcode.sizeVersion(7);break;case"version8":qRCodeBarcode.sizeVersion(8);break;case"version9":qRCodeBarcode.sizeVersion(9);break;case"version10":qRCodeBarcode.sizeVersion(10);break;case"version11":qRCodeBarcode.sizeVersion(11);break;case"version12":qRCodeBarcode.sizeVersion(12);break;case"version13":qRCodeBarcode.sizeVersion(13);break;case"version14":qRCodeBarcode.sizeVersion(14);break;case"version15":qRCodeBarcode.sizeVersion(15);break;case"version16":qRCodeBarcode.sizeVersion(16);break;case"version17":qRCodeBarcode.sizeVersion(17);break;case"version18":qRCodeBarcode.sizeVersion(18);break;case"version19":qRCodeBarcode.sizeVersion(19);break;case"version20":qRCodeBarcode.sizeVersion(20);break;case"version21":qRCodeBarcode.sizeVersion(21);break;case"version22":qRCodeBarcode.sizeVersion(22);break;case"version23":qRCodeBarcode.sizeVersion(23);break;case"version24":qRCodeBarcode.sizeVersion(24);break;case"version25":qRCodeBarcode.sizeVersion(25);break;case"version26":qRCodeBarcode.sizeVersion(26);break;case"version27":qRCodeBarcode.sizeVersion(27);break;case"version28":qRCodeBarcode.sizeVersion(28);break;case"version29":qRCodeBarcode.sizeVersion(29);break;case"version30":qRCodeBarcode.sizeVersion(30);break;case"version31":qRCodeBarcode.sizeVersion(31);break;case"version32":qRCodeBarcode.sizeVersion(32);break;case"version33":qRCodeBarcode.sizeVersion(33);break;case"version34":qRCodeBarcode.sizeVersion(34);break;case"version35":qRCodeBarcode.sizeVersion(35);break;case"version36":qRCodeBarcode.sizeVersion(36);break;case"version37":qRCodeBarcode.sizeVersion(37);break;case"version38":qRCodeBarcode.sizeVersion(38);break;case"version39":qRCodeBarcode.sizeVersion(39);break;case"version40":qRCodeBarcode.sizeVersion(40);break}return true;case"encodingMode":switch(value){case"undefined":qRCodeBarcode.encodingMode(-1);break;case"numeric":qRCodeBarcode.encodingMode(0);break;case"alphanumeric":qRCodeBarcode.encodingMode(1);break;case"byte":qRCodeBarcode.encodingMode(2);break;case"kanji":qRCodeBarcode.encodingMode(3);break}return true;case"eciNumber":qRCodeBarcode.eciNumber(value);return true;case"eciHeaderDisplayMode":switch(value){case"hide":qRCodeBarcode.eciHeaderDisplayMode(0);break;case"show":qRCodeBarcode.eciHeaderDisplayMode(1);break}return true;case"fnc1Mode":switch(value){case"none":qRCodeBarcode.fnc1Mode(0);break;case"gs1":qRCodeBarcode.fnc1Mode(1);break;case"industry":qRCodeBarcode.fnc1Mode(2);break}return true;case"applicationIndicator":qRCodeBarcode.applicationIndicator(value);return true}},_set_option:function(qRCodeBarcode,key,value){var currentKey;switch(key){case"width":this._setSize(qRCodeBarcode,"width",value);return true;case"height":this._setSize(qRCodeBarcode,"height",value);return true}},_creationOptions:null,_qRCodeBarcode:null,_createWidget:function(options,element,widget){this._creationOptions=options;$.Widget.prototype._createWidget.apply(this,[options,element])},_create:function(){var key,v,size,qRCodeBarcode,width,height,i=-1,self=this,elem=self.element,style=elem[0].style,o=this._creationOptions;self._old_state={style:{position:style.position,width:style.width,height:style.height},css:elem[0].className,elems:elem.find("*")};if(!$.ig.util._isCanvasSupported()){$.ig.util._renderUnsupportedBrowser(this);return}qRCodeBarcode=this._createBarcode();self._qRCodeBarcode=qRCodeBarcode;qRCodeBarcode.errorMessageDisplaying=$.ig.Delegate.prototype.combine(qRCodeBarcode.errorMessageDisplaying,jQuery.proxy(this._fireQRCodeBarcode_errorMessageDisplaying,this));qRCodeBarcode.dataChanged=$.ig.Delegate.prototype.combine(qRCodeBarcode.dataChanged,jQuery.proxy(this._fireQRCodeBarcode_dataChanged,this));if(o.hasOwnProperty("width"))elem[0].style.width=o["width"];if(o.hasOwnProperty("height"))elem[0].style.height=o["height"];qRCodeBarcode.provideContainer(elem[0]);for(key in o){if(o.hasOwnProperty(key)){v=o[key];if(v!==null){this._setOption(key,v,false)}}}while(i++<1){key=i===0?"width":"height";if(o[key]){size=key;v=o[key]}else{v=elem[0].style[key]}if(v&&v.indexOf("%")>0){self._setSize(qRCodeBarcode,size=key,v)}}if(!size){self._setSize(qRCodeBarcode,"width")}if(self.css&&self.css.qRCodeBarcode){elem.addClass(self.css.qRCodeBarcode)}},_createBarcode:function(){return new $.ig.XamQRCodeBarcode},_fireQRCodeBarcode_dataChanged:function(barcode,evt){var opts={};opts.newData=evt.newData();opts.owner=this;this._trigger("dataChanged",null,opts)},_fireQRCodeBarcode_errorMessageDisplaying:function(barcode,evt){var opts={};opts.errorMessage=evt.errorMessage();opts.owner=this;this._trigger("errorMessageDisplaying",null,opts);evt.errorMessage(opts.errorMessage)},_setSize:function(qRCodeBarcode,key,val){$.ig.util.setSize(this.element,key,val,qRCodeBarcode,this._getNotifyResizeName())},_getNotifyResizeName:function(){return"containerResized"},exportVisualData:function(){if(this._qRCodeBarcode)return this._qRCodeBarcode.exportVisualData()},flush:function(){if(this._qRCodeBarcode&&this._qRCodeBarcode.view())this._qRCodeBarcode.view().flush()},destroy:function(){var key,style,qRCodeBarcode=this._qRCodeBarcode,old=this._old_state,elem=this.element;if(!old){return}elem.find("*").not(old.elems).remove();if(this.css.qRCodeBarcode){elem.removeClass(this.css.qRCodeBarcode)}old=old.style;style=elem[0].style;for(key in old){if(old.hasOwnProperty(key)){if(style[key]!==old[key]){style[key]=old[key]}}}if(qRCodeBarcode){this._setSize(qRCodeBarcode)}$.Widget.prototype.destroy.apply(this,arguments);if(qRCodeBarcode&&qRCodeBarcode.destroy){qRCodeBarcode.destroy()}delete this._qRCodeBarcode;delete this._old_state},styleUpdated:function(){if(this._qRCodeBarcode&&this._qRCodeBarcode.view()){this._qRCodeBarcode.view().styleUpdated()}}});$.extend($.ui.igQRCodeBarcode,{version:"16.2.20162.2040"});return $.ui.igQRCodeBarcode});