(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["about"],{9493:function(e,t,n){"use strict";n.r(t);var r=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"dokumenti"},[n("b-container",[e.loadingPage?n("b-spinner",{staticClass:"mt-5"}):e._e(),e.showForm?n("OsnovniPodaci",{on:{submit:e.submitData}}):e._e(),e.showForm||e.loadingPage?e._e():n("b-table-simple",{attrs:{hover:"",small:"","caption-top":"",responsive:""}},[n("caption",[e._v(" Dokumenti: ")]),n("colgroup",[n("col"),n("col")]),n("colgroup",[n("col"),n("col"),n("col")]),n("colgroup",[n("col"),n("col")]),n("b-thead",{attrs:{"head-variant":"dark"}},[n("b-tr",[n("b-th",[e._v("Dokument")]),n("b-th",[e._v("Predano")]),n("b-th",[e._v("Predaj/Preuzmi")])],1)],1),n("b-tbody",[n("b-tr",[n("b-td",[e._v("Anketa")]),null===e.dokumenti.anketa?n("b-td",{staticStyle:{"font-size":"3rem"},attrs:{variant:"danger"}},[n("BIconXOctagon")],1):n("b-td",{staticStyle:{"font-size":"3rem"},attrs:{variant:"success"}},[n("BIconCheckCircle")],1),n("b-td",{staticStyle:{"font-size":"3 rem"}},[n("b-button",{staticClass:"mt-3",attrs:{id:"anketaButton",variant:null===e.dokumenti.anketa?"danger":"success"},on:{click:function(t){e.anketaModal=!0}}},[n("b-icon-text-center")],1),null===e.dokumenti.anketa?n("b-tooltip",{attrs:{target:"anketaButton",triggers:"hover"}},[e._v(" Popuni anketu ")]):n("b-tooltip",{attrs:{target:"anketaButton",triggers:"hover"}},[e._v(" Uredi anketu ")])],1)],1),n("b-tr",[n("b-td",[e._v("Dnevnik")]),null===e.dokumenti.dnevnik?n("b-td",{staticStyle:{"font-size":"3rem"},attrs:{variant:"danger"}},[n("BIconXOctagon")],1):n("b-td",{staticStyle:{"font-size":"3rem"},attrs:{variant:"success"}},[n("BIconCheckCircle")],1),n("b-td",{staticStyle:{"font-size":"3rem"}},[null===e.dokumenti.dnevnik?n("b-button",{staticClass:"mr-3",attrs:{variant:"outline-primary"},on:{click:e.uploadDnevnik}},[n("BIconUpload")],1):e._e(),n("b-button",{style:null===e.dokumenti.dnevnik?"cursor:not-allowed;":null,attrs:{id:"downloadDnevnik",disabled:null===e.dokumenti.dnevnik,variant:null===e.dokumenti.dnevnik?"danger":"success"},on:{click:function(t){return e.downloadDocument(e.dokumenti.dnevnik)}}},[n("BIconDownload")],1),null!==e.dokumenti.dnevnik?n("b-button-close",{attrs:{id:"deleteDnevnik"},on:{click:e.izbrisiDnevnik}}):e._e(),n("b-tooltip",{attrs:{target:"deleteDnevnik",triggers:"hover"}},[e._v(" Izbrisi dodani dnevnik ")]),n("b-tooltip",{attrs:{target:"downloadDnevnik",triggers:"hover"}},[e._v(" Preuzmi dnevnik ")])],1)],1),n("b-tr",[n("b-td",[e._v("Izvjesce")]),null===e.dokumenti.izvjesce?n("b-td",{staticStyle:{"font-size":"3rem"},attrs:{variant:"danger"}},[n("BIconXOctagon")],1):n("b-td",{staticStyle:{"font-size":"3rem"},attrs:{variant:"success"}},[n("BIconCheckCircle")],1),n("b-td",{staticClass:"text-center",staticStyle:{"font-size":"3rem"}},[null===e.dokumenti.izvjesce?n("b-button",{staticClass:"mr-3",attrs:{variant:"outline-primary"},on:{click:e.uploadIzvjesce}},[n("BIconUpload")],1):e._e(),n("b-button",{style:null===e.dokumenti.izvjesce?"cursor:not-allowed;":null,attrs:{id:"downloadIzvjesce",disabled:null===e.dokumenti.izvjesce,variant:null===e.dokumenti.izvjesce?"danger":"success"},on:{click:function(t){return e.downloadDocument(e.dokumenti.izvjesce)}}},[n("BIconDownload")],1),n("b-tooltip",{attrs:{target:"downloadIzvjesce",triggers:"hover"}},[e._v(" Preuzmi izvjesce ")]),null!==e.dokumenti.izvjesce?n("b-button-close",{attrs:{id:"deleteIzvjesce"},on:{click:e.izbrisiIzvjesce}}):e._e(),null!==e.dokumenti.izvjesce?n("b-tooltip",{attrs:{target:"deleteIzvjesce",triggers:"hover"}},[e._v(" Izbrisi dodano izvjesce ")]):e._e()],1),n("input",{ref:"izvjesceFileInput",staticStyle:{display:"none"},attrs:{type:"file"},on:{change:e.izvjesceAdded}}),n("input",{ref:"dnevnikFileInput",staticStyle:{display:"none"},attrs:{type:"file"},on:{change:e.dnevnikAdded}})],1)],1),n("b-tfoot",[n("b-tr",[n("b-td",{attrs:{colspan:"7",variant:"secondary"}})],1)],1)],1),n("b-button",{attrs:{variant:"success",block:""}},[e._v("Generiraj PDF Izvjesca")])],1),e.anketaModal?n("Anketa",{attrs:{viewMode:!1,data:e.dokumenti.anketa,model:e.anketaModal},on:{anketaPredana:e.anketaPredana,updateAnketa:e.updateAnketa,closeModal:function(t){e.anketaModal=!1}}}):e._e()],1)},a=[],o=(n("c975"),n("d3b7"),n("ac1f"),n("3ca3"),n("5319"),n("ddb0"),n("2b3d"),n("96cf"),n("1da1")),i=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",[n("b-card",{staticClass:"mt-3",attrs:{header:"Osnovni podaci "+e.akGodina}},[e.show?n("b-form",{on:{submit:e.onSubmit}},[n("b-form-group",{attrs:{id:"input-group-1",label:"Poduzece:",required:"","label-for":"input-1",description:"Ime poduzeca u kojem ce se obavljati strucna praksa"}},[n("b-form-input",{attrs:{id:"input-1",required:"",placeholder:"Poduzece"},model:{value:e.form.poduzece,callback:function(t){e.$set(e.form,"poduzece",t)},expression:"form.poduzece"}})],1),n("b-form-group",{attrs:{id:"input-group-3",label:"Naziv mentora:","label-for":"input-3"}},[n("b-form-input",{attrs:{id:"input-2",required:"",placeholder:"Naziv mentora"},model:{value:e.form.nazivMentora,callback:function(t){e.$set(e.form,"nazivMentora",t)},expression:"form.nazivMentora"}})],1),n("b-button",{attrs:{type:"submit",variant:"primary"}},[e._v("Prijava")])],1):e._e()],1)],1)},s=[],c=(n("99af"),{data:function(){return{form:{poduzece:"",nazivMentora:""},show:!0,godina:new Date}},computed:{akGodina:function(){return"".concat(this.godina.getFullYear(),"/").concat(this.godina.getFullYear()-1)}},methods:{onSubmit:function(e){e.preventDefault(),this.$emit("submit",this.form)}}}),u=c,l=n("2877"),d=Object(l["a"])(u,i,s,!1,null,null,null),v=d.exports,p=n("bbe8"),m={name:"home",components:{OsnovniPodaci:v,Anketa:p["a"]},data:function(){return{loadingPage:null,anketaModal:!1,showForm:!1,dokumenti:{anketa:null,izvjesce:null,dnevnik:null}}},methods:{updateAnketa:function(e){var t=this;return Object(o["a"])(regeneratorRuntime.mark((function n(){var r;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return e.peto||delete e.sesto,console.log(e),n.prev=2,n.next=5,t.$axios.post("api/dokumenti/updateAnketa",e);case 5:r=n.sent,console.log(r,"anketa UPDATEANA !!!!!!!!!!!!!!!!!!!"),t.dokumenti.anketa=r.data,t.anketaModal=!1,n.next=14;break;case 11:n.prev=11,n.t0=n["catch"](2),console.log(n.t0.response);case 14:case"end":return n.stop()}}),n,null,[[2,11]])})))()},anketaPredana:function(e){var t=this;return Object(o["a"])(regeneratorRuntime.mark((function n(){var r;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return e.peto||delete e.sesto,console.log(e),n.prev=2,n.next=5,t.$axios.post("api/dokumenti/setAnketa",e);case 5:r=n.sent,console.log(r,"anketa dodana ???????????????????"),t.dokumenti.anketa=r.data,t.anketaModal=!1,n.next=14;break;case 11:n.prev=11,n.t0=n["catch"](2),console.log(n.t0.response);case 14:case"end":return n.stop()}}),n,null,[[2,11]])})))()},izbrisiDnevnik:function(){var e=this;return Object(o["a"])(regeneratorRuntime.mark((function t(){var n;return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return t.prev=0,t.next=3,e.$axios.delete("api/dokumenti/deleteDnevnik");case 3:n=t.sent,console.log("res",n),1===n.data&&(e.dokumenti.dnevnik=null),t.next=11;break;case 8:t.prev=8,t.t0=t["catch"](0),console.log("EEEEEE",t.t0);case 11:case"end":return t.stop()}}),t,null,[[0,8]])})))()},izbrisiIzvjesce:function(){var e=this;return Object(o["a"])(regeneratorRuntime.mark((function t(){var n;return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return t.prev=0,t.next=3,e.$axios.delete("api/dokumenti/deleteIzvjesce");case 3:n=t.sent,console.log("res",n),1===n.data&&(e.dokumenti.izvjesce=null),t.next=11;break;case 8:t.prev=8,t.t0=t["catch"](0),console.log("EEEEEE",t.t0);case 11:case"end":return t.stop()}}),t,null,[[0,8]])})))()},uploadIzvjesce:function(){var e=this;return Object(o["a"])(regeneratorRuntime.mark((function t(){return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:e.$refs.izvjesceFileInput.click();case 1:case"end":return t.stop()}}),t)})))()},uploadDnevnik:function(){var e=this;return Object(o["a"])(regeneratorRuntime.mark((function t(){return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:e.$refs.dnevnikFileInput.click();case 1:case"end":return t.stop()}}),t)})))()},izvjesceAdded:function(e){var t=this;return Object(o["a"])(regeneratorRuntime.mark((function n(){var r;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:if(0==e.target.files.length){n.next=6;break}return n.next=3,t.uploadIzvjesceToServer(e.target.files[0]);case 3:r=n.sent,console.log(r),null!==r&&(t.dokumenti.izvjesce=r);case 6:case"end":return n.stop()}}),n)})))()},dnevnikAdded:function(e){var t=this;return Object(o["a"])(regeneratorRuntime.mark((function n(){var r;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:if(console.log("dnevnik added",e),0==e.target.files.length){n.next=7;break}return n.next=4,t.uploadDnevnikToServer(e.target.files[0]);case 4:r=n.sent,console.log(r),null!==r&&(t.dokumenti.dnevnik=r);case 7:case"end":return n.stop()}}),n)})))()},uploadIzvjesceToServer:function(e){var t=this;return Object(o["a"])(regeneratorRuntime.mark((function n(){var r,a,o;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return n.prev=0,r=new FormData,r.append("izvjesceFile",e),n.next=5,t.$axios.post("api/dokumenti/setIzvjesce",r,{headers:{"Content-Type":"multipart/form-data"}});case 5:return a=n.sent,o=a.data,o.fileUrl="/api/dokumenti/getIzvjesce",n.abrupt("return",o);case 11:return n.prev=11,n.t0=n["catch"](0),console.log("errrorrrrrrrrrrrrrrrrrrrrrrrrrrr",n.t0),n.abrupt("return",null);case 15:case"end":return n.stop()}}),n,null,[[0,11]])})))()},uploadDnevnikToServer:function(e){var t=this;return Object(o["a"])(regeneratorRuntime.mark((function n(){var r,a,o;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return n.prev=0,r=new FormData,r.append("dnevnikFile",e),n.next=5,t.$axios.post("api/dokumenti/setDnevnik",r,{headers:{"Content-Type":"multipart/form-data"}});case 5:return a=n.sent,o=a.data,o.fileUrl="/api/dokumenti/getDnevnik",n.abrupt("return",o);case 11:return n.prev=11,n.t0=n["catch"](0),console.log("errrorrrrrrrrrrrrrrrrrrrrrrrrrrr",n.t0),n.abrupt("return",null);case 15:case"end":return n.stop()}}),n,null,[[0,11]])})))()},downloadDocument:function(e){var t=this;return Object(o["a"])(regeneratorRuntime.mark((function n(){var r,a,o,i,s,c,u;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return console.log(e),n.prev=1,n.next=4,t.$axios.get(e.fileUrl,{responseType:"blob"});case 4:r=n.sent,a=window.URL.createObjectURL(new Blob([r.data])),o=document.createElement("a"),o.href=a,i=r.headers["content-disposition"],s="doc.pdf",i&&-1!==i.indexOf("attachment")&&(c=/filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/,u=c.exec(i),null!=u&&u[1]&&(s=u[1].replace(/['"]/g,""))),o.setAttribute("download",s),document.body.appendChild(o),o.click(),n.next=19;break;case 16:n.prev=16,n.t0=n["catch"](1),console.log(n.t0);case 19:case"end":return n.stop()}}),n,null,[[1,16]])})))()},submitData:function(e){var t=this;return Object(o["a"])(regeneratorRuntime.mark((function n(){var r,a;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return t.loadingPage=!0,console.log(e),n.prev=2,r={IdUsera:localStorage.getItem("id"),Termin:null,Poduzece:e.poduzece,NazivMentora:e.nazivMentora},n.next=6,t.$axios.post("/api/osnovniPodaci/setOsnovniPodaci",r);case 6:a=n.sent,console.log("saveOsnovniPodaci",a),t.showForm=!1,t.loadingPage=!1,n.next=15;break;case 12:n.prev=12,n.t0=n["catch"](2),console.log(n.t0.response);case 15:case"end":return n.stop()}}),n,null,[[2,12]])})))()},getAllDocuments:function(){var e=this;return Object(o["a"])(regeneratorRuntime.mark((function t(){var n,r;return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return t.prev=0,t.next=3,e.$axios.get("/api/dokumenti/getDocuments");case 3:return n=t.sent,r=n.data,r.anketa,null!==r.dnevnik&&(r.dnevnik.fileUrl="/api/dokumenti/getDnevnik"),null!==r.izvjesce&&(r.izvjesce.fileUrl="/api/dokumenti/getIzvjesce"),t.abrupt("return",r);case 11:return t.prev=11,t.t0=t["catch"](0),t.abrupt("return",{anketa:null,izvjesce:null,dnevnik:null});case 14:case"end":return t.stop()}}),t,null,[[0,11]])})))()}},created:function(){var e=this;return Object(o["a"])(regeneratorRuntime.mark((function t(){var n,r,a;return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return e.loadingPage=!0,n=localStorage.getItem("id"),t.prev=2,t.next=5,e.$axios.get("/api/osnovniPodaci/getOsnovniPodaci/".concat(n));case 5:if(r=t.sent,204!=r.status){t.next=10;break}e.showForm=!0,t.next=14;break;case 10:return t.next=12,e.getAllDocuments(e.$axios);case 12:a=t.sent,e.dokumenti=a;case 14:t.next=19;break;case 16:t.prev=16,t.t0=t["catch"](2),e.$bvToast.toast("Pogreska kod dohvacanja dokumenata ".concat(t.t0.response.message),{title:"Pogreska",autoHideDelay:4e3});case 19:e.loadingPage=!1;case 20:case"end":return t.stop()}}),t,null,[[2,16]])})))()}},k=m,b=Object(l["a"])(k,r,a,!1,null,null,null);t["default"]=b.exports}}]);
//# sourceMappingURL=about.44aaa96f.js.map