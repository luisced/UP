from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from flask_bcrypt import Bcrypt
from flask_login import LoginManager
from flask import Flask
from pharmacy.config import Config
from flask_cors import CORS
from flask_session import Session
import logging
db = SQLAlchemy()
bcrypt = Bcrypt()
login_manager = LoginManager()
login_manager.login_view = 'main.login'
login_manager.login_message_category = 'info'

# Configure logging
logging.basicConfig(level=logging.INFO,)
formatter = logging.Formatter(
    '%(levelname)s - %(message)s')
handler = logging.StreamHandler()
handler.setFormatter(formatter)


@ login_manager.user_loader
def create_app(config_class=Config):
    app = Flask(__name__)
    app.config["SESSION_PERMANENT"] = False
    app.config["SESSION_TYPE"] = "filesystem"
    app.config.from_object(Config)
    Session(app)
    CORS(app)

    # CORS(app, resources={r"/*": {"origins": "*"}})
    db.init_app(app)
    bcrypt.init_app(app)
    login_manager.init_app(app)

    app.app_context().push()

    from pharmacy.products.routes import product
    from pharmacy.sales.routes import sale

    app.config.from_object(Config)
    app.register_blueprint(product)
    app.register_blueprint(sale)

    return app
