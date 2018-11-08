
    
var uploadFileArray = [];
var FileArray = [];
var limitFiles;

$(function() {
    var names = [];
    $('body').on('change', '.picupload', function(event) {
        var getAttr = $(this).attr('click-type');
        var files = event.target.files;
        var output = document.getElementById("media-list");
        var z = 0
        var ValidImageTypes = ["image/gif", "image/jpeg", "image/png"];

        if (getAttr == 'type1') {

            $('#media-list').html('');
            $('#media-list').html('<li class="myupload" id="myupload"><span><i class="fa fa-plus" aria-hidden="true"></i><input type="file" click-type="type2" id="picupload" accept="image/*" class="picupload" multiple></span></li>');
            $('#hint_brand').modal('show');

                for (var i = 0; i < files.length; i++) {
                    if(names.length >= limitFiles){
                        alert("Upload Files Limit = " + limitFiles)
                        document.getElementById("myupload").style.display = "none"
                        return;
                    }

                    var file = files[i];
                    var fileType = file["type"];

                    if ($.inArray(fileType, ValidImageTypes) < 0) {
                        return;
                    }

                    names.push($(this).get(0).files[i].name);
                    FileArray.push($(this).get(0).files[i]);
                
                    if (file.type.match('image')) {
                        var picReader = new FileReader();
                        picReader.fileName = file.name
                        picReader.addEventListener("load", function(event) {
                            var picFile = event.target;

                            var div = document.createElement("li");

                            div.innerHTML = "<img src='" + picFile.result + "'" +
                                "title='" + picFile.name + "'/><div  class='post-thumb'><div class='inner-post-thumb'><a href='javascript:void(0);' data-id='" + event.target.fileName + "' class='remove-pic'><i class='fa fa-times' aria-hidden='true'></i></a><div></div>";

                            $("#media-list").prepend(div);
                        });
                    } else {

                        var picReader = new FileReader();
                        picReader.fileName = file.name
                        picReader.addEventListener("load", function(event) {

                            var picFile = event.target;

                            var div = document.createElement("li");

                            div.innerHTML = "<video src='" + picFile.result + "'" +
                                "title='" + picFile.name + "'></video><div id='" + z + "'  class='post-thumb'><div  class='inner-post-thumb'><a data-id='" + event.target.fileName + "' href='javascript:void(0);' class='remove-pic'><i class='fa fa-times' aria-hidden='true'></i></a><div></div>";
                            $("#media-list").prepend(div);

                        });

                    }
                    picReader.readAsDataURL(file);
                }
                
                copyArray();
        } else if (getAttr == 'type2') {

            console.log(limitFiles);
           
                for (var i = 0; i < files.length; i++) {
                    if(names.length >= limitFiles){
                        alert("Upload Files Limit = " + limitFiles)
                        document.getElementById("myupload").style.display = "none"
                        return;
                    }

                    var file = files[i];
                    var fileType = file["type"];

                    if ($.inArray(fileType, ValidImageTypes) < 0) {
                        return;
                    }
                    
                    var file = files[i];
                    names.push($(this).get(0).files[i].name);
                    FileArray.push($(this).get(0).files[i]);

                    if (file.type.match('image')) {

                        var picReader = new FileReader();
                        picReader.fileName = file.name
                        picReader.addEventListener("load", function(event) {

                            var picFile = event.target;

                            var div = document.createElement("li");

                            div.innerHTML = "<img src='" + picFile.result + "'" +
                                "title='" + picFile.name + "'/><div  class='post-thumb'><div class='inner-post-thumb'><a href='javascript:void(0);' data-id='" + event.target.fileName + "' class='remove-pic'><i class='fa fa-times' aria-hidden='true'></i></a><div></div>";

                            $("#media-list").prepend(div);

                        });
                    } else {
                        var picReader = new FileReader();
                        picReader.fileName = file.name
                        picReader.addEventListener("load", function(event) {

                            var picFile = event.target;

                            var div = document.createElement("li");

                            div.innerHTML = "<video src='" + picFile.result + "'" +
                                "title='" + picFile.name + "'></video><div class='post-thumb'><div  class='inner-post-thumb'><a href='javascript:void(0);' data-id='" + event.target.fileName + "' class='remove-pic'><i class='fa fa-times' aria-hidden='true'></i></a><div></div>";

                            $("#media-list").prepend(div);

                        });
                    }
                    picReader.readAsDataURL(file);
                }
                                    
                copyArray();
        }

    });

    $('body').on('click', '.remove-pic', function() {
        $(this).parent().parent().parent().remove();
        var removeItem = $(this).attr('data-id');
        var yet = names.indexOf(removeItem);

        if (yet != -1) {
            names.splice(yet, 1);
            FileArray.splice(yet, 1);
        }

        if(names.length == (limitFiles-1) ){
            document.getElementById("myupload").style.display = "unset";
        }

        copyArray();
    });

    $('#hint_brand').on('hidden.bs.modal', function(e) {
        names = [];
        FileArray = [];
        z = 0;
    });

    function copyArray(){
        uploadFileArray = [];

        for(var i = 0; i < names.length ; i++){
            uploadFileArray[i] = names[i];
        }

        if(names.length >= limitFiles){
            document.getElementById("myupload").style.display = "none"
        }
    }
});
